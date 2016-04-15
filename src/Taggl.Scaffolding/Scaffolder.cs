﻿using Microsoft.Extensions.CodeGeneration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Scaffolding.Utility;

namespace Taggl.Scaffolding
{
    public class Scaffolder
    {
        private const string CodeFileExtension = "cs";
        private const string TemplateFileExtension = "cshtml";

        private readonly ICodeGeneratorActionsService _codeGeneratorActionsService;
        private readonly IApplicationEnvironment _applicationEnvironment;
        private readonly ILibraryManager _libraryManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;
        private readonly NameResolver _nameResolver;

        public Scaffolder(
            ICodeGeneratorActionsService codeGeneratorActionsService,
            IApplicationEnvironment applicationEnvironment,
            ILibraryManager libraryManager,
            IServiceProvider serviceProvider,
            ILogger logger)
        {
            _codeGeneratorActionsService = codeGeneratorActionsService;
            _applicationEnvironment = applicationEnvironment;
            _libraryManager = libraryManager;
            _serviceProvider = serviceProvider;
            _logger = logger;

            _nameResolver = ActivatorUtilities.CreateInstance<NameResolver>(_serviceProvider);
        }

        public async Task ScaffoldServiceAsync(
            string areaName,
            string entityName,
            string serviceName,
            object templateModel,
            bool force = false)
        {
            string outputFileName = BuildOutputFileName(areaName, entityName, serviceName, force);
            var directoryResolver = ActivatorUtilities.CreateInstance<DirectoryResolver>(_serviceProvider);
            string templateFolder = directoryResolver.GetTemplateFolder(ScaffoldType.Service);
            await _codeGeneratorActionsService.AddFileFromTemplateAsync(
                outputFileName, $"ServiceTemplate.{TemplateFileExtension}", templateFolder, templateModel);
        }

        #region Helpers

        private string BuildOutputFileName(string areaName, string entityName, string serviceName, bool force)
        {
            string srcPath = Directory.GetParent(_applicationEnvironment.ApplicationBasePath).FullName;
            string directory = Path.Combine(srcPath, _nameResolver.GetServicesNamespace(), areaName);
            if (!Directory.Exists(directory))
            {
                _logger.LogMessage($"Directory {directory} did not exist, creating...");
                Directory.CreateDirectory(directory);
            }

            string outputFileName = Path.Combine(directory, $"{serviceName}.{CodeFileExtension}");
            if (File.Exists(outputFileName) && !force)
            {
                throw new InvalidOperationException($"The file {outputFileName} exists, use -f option to overwrite");
            }

            return outputFileName;
        }

        #endregion
    }
}
