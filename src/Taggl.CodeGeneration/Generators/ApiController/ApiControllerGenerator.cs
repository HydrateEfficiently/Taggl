﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Services;
using Taggl.CodeGeneration.Services.CodeDeclarations;
using Taggl.CodeGeneration.Services.Environment;
using Taggl.CodeGeneration.Utility;
using Taggl.Framework.Services;

namespace Taggl.CodeGeneration.Generators.ApiController
{
    public class ApiControllerGenerator : IGenerator
    {
        private struct ProjectTypeAndServiceName
        {
            public LocalProjectType ProjectType;
            public string ServiceName;
        }

        private readonly ProjectTypeAndServiceName[] DefaultInjectedServices = new ProjectTypeAndServiceName[]
        {
            new ProjectTypeAndServiceName()
            {
                ProjectType = LocalProjectType.Framework,
                ServiceName = nameof(IIdentityResolver)
            }
        };

        private readonly NamespaceService _namespaceService;
        private readonly IServiceReflector _serviceReflector;
        private readonly IMemberDeclarationModelFactory _memberDeclarationModelFactory;
        private readonly ILocalProjectTypeResolver _localProjectTypeResolver;
        private readonly IAssemblyProvider _assemblyProvider;
        private readonly OutputPathResolver _outputPathResolver;
        private readonly ScaffoldingService _scaffoldingService;
        private readonly ApiControllerCommandLineModel _model;

        public ApiControllerGenerator(
            NamespaceService namespaceService,
            IServiceReflector serviceReflector,
            IMemberDeclarationModelFactory memberDeclarationModelFactory,
            ILocalProjectTypeResolver localProjectTypeResolver,
            IAssemblyProvider assemblyProvider,
            OutputPathResolver outputPathResolver,
            ScaffoldingService scaffoldingService,
            ApiControllerCommandLineModel model)
        {
            _namespaceService = namespaceService;
            _serviceReflector = serviceReflector;
            _memberDeclarationModelFactory = memberDeclarationModelFactory;
            _localProjectTypeResolver = localProjectTypeResolver;
            _assemblyProvider = assemblyProvider;
            _outputPathResolver = outputPathResolver;
            _scaffoldingService = scaffoldingService;
            _model = model;
        }

        public async Task Generate()
        {
            string serviceName = _model.Service;
            string areaName = _serviceReflector.GetAreaName(serviceName);

            var usingNamespaceNames = new List<string>()
            {
                _namespaceService.GetServicesNamespace(),
                _namespaceService.GetServiceNamespace(areaName),
                _namespaceService.GetServiceModelsNamespace(areaName)
            };

            var serviceType = _serviceReflector.GetServiceType(serviceName);
            var service = _memberDeclarationModelFactory.CreateInjectedService(serviceType);
            var injectedServices = new List<MemberDeclarationModel>() { service };

            var servicesToInject = _model.Inject.Split(',')
                .Select(s => GetProjectTypeAndServiceName(s))
                .Union(DefaultInjectedServices);
            foreach (var serviceToInject in servicesToInject)
            {
                var assembly = _assemblyProvider.GetAssembly(serviceToInject.ProjectType);
                var serviceToInjectType = assembly.GetTypeAndValidate(serviceToInject.ServiceName);
                injectedServices.Add(_memberDeclarationModelFactory.CreateInjectedService(serviceToInjectType));

                string serviceNamespaceName = serviceToInjectType.Namespace;
                if (!usingNamespaceNames.Contains(serviceNamespaceName))
                {
                    usingNamespaceNames.Add(serviceNamespaceName);
                }
            }

            var actionDeclarationModels = serviceType.GetMethods()
                .Where(mi => mi.IsPublic)
                .Select(mi => CreateActionDeclarationModel(mi));

            const string ServiceSuffix = "Service";
            string serviceBaseName = serviceName.EndsWith(ServiceSuffix) ?
                serviceName.Substring(0, serviceName.Length - "Service".Length) :
                serviceName;

            string apiControllerName = $"{serviceBaseName}ApiController";

            var templateModel = new ApiControllerTemplateModel()
            {
                ClassName = apiControllerName,
                Service = service,
                NamespaceName = _namespaceService.GetWebApiControllerNamespace(areaName),
                UsingNamespaceNames = usingNamespaceNames.AsEnumerable().OrderBy(s => s),
                InjectedServices = injectedServices,
                Actions = actionDeclarationModels
            };

            await _scaffoldingService.ScaffoldAsync(
                _outputPathResolver.GetWebApiControllerPath(areaName),
                apiControllerName,
                "ApiControllerFromServiceTemplate",
                templateModel,
                force: _model.Force);
        }

        private ProjectTypeAndServiceName GetProjectTypeAndServiceName(string injectedService)
        {
            var injectedServiceSplit = injectedService.Split(':');
            string projectTypeArg;
            string serviceName;
            if (injectedServiceSplit.Length == 1)
            {
                projectTypeArg = "s";
                serviceName = injectedServiceSplit[0];
            }
            else if (injectedServiceSplit.Length == 2)
            {
                projectTypeArg = injectedServiceSplit[0];
                serviceName = injectedServiceSplit[1];
            }
            else
            {
                throw new InvalidOperationException(
                    $"Unrecognised injected service command, '{injectedService}', must be in format <project-type>:<service-name> or <service-name>");
            }
            var projectType = _localProjectTypeResolver.Resolve(projectTypeArg);
            return new ProjectTypeAndServiceName()
            {
                ProjectType = projectType,
                ServiceName = serviceName
            };
        }

        private ActionDeclarationModel CreateActionDeclarationModel(MethodInfo serviceMethod)
        {
            bool isAsync = serviceMethod.IsAsync();
            string serviceMethodBaseName = serviceMethod.Name;
            if (isAsync)
            {
                const string AsyncSuffix = "Async";
                if (!serviceMethodBaseName.EndsWith(AsyncSuffix))
                {
                    throw new InvalidOperationException($"Async method {serviceMethodBaseName} must end in '{AsyncSuffix}'");
                }
                serviceMethodBaseName += AsyncSuffix;
            }

            var serviceMethodParams = serviceMethod.GetParameters();
            // Assume that if the service takes one class, that the it will be included via an HTTP POST request's body.
            // Else, the arguments to the service will be included in an HTTP GET request as route values.
            bool serviceMethodRequiresModel = serviceMethodParams.Count() == 1 &&
                serviceMethodParams.First().GetType().IsClass;

            IEnumerable<string> resolvedParameterNames;
            var parametersNames = serviceMethodParams.Select(p => p.Name);
            string routeName = serviceMethodBaseName.ToFirstCharacterLower();
            var attributes = new List<string>();
            if (serviceMethodRequiresModel)
            {
                attributes.Add("[HttpPost]");
                attributes.Add($"[Route(\"{routeName}\")]");
                var serviceMethodParam = serviceMethodParams.First();
                resolvedParameterNames = new List<string>()
                {
                    $"[FromBody] {serviceMethodParam.ParameterType.Name} {serviceMethodParam.Name}"
                };
            }
            else
            {
                attributes.Add($"[HttpGet]");
                var routeTemplateParts = new List<string>() { routeName };
                routeTemplateParts.AddRange(parametersNames.Select(p => $"{{{p}}}"));
                attributes.Add($"[Route(\"{Path.Combine(routeTemplateParts.ToArray())}\")]");
                resolvedParameterNames = serviceMethodParams
                    .Select(p => $"{p.ParameterType.Name} {p.Name}");
            }
            
            return new ActionDeclarationModel()
            {
                Attributes = attributes,
                Method = new MethodDeclarationModel()
                {
                    Parameters = resolvedParameterNames,
                    ReturnTypeName = isAsync ? "Task<IActionResult>" : "IActionResult"
                },
                ServiceMethod = new ServiceMethodInvocationModel()
                {
                    BaseName = serviceMethodBaseName,
                    ReturnTypeName = serviceMethod.ReturnType.Name,
                    IsAsync = isAsync
                }
            };
        }
    }
}
