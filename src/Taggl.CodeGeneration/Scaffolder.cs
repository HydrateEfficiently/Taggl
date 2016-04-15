using Microsoft.Extensions.CodeGeneration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration
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
        private readonly DirectoryResolver _directoryResolver;

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
            _directoryResolver = ActivatorUtilities.CreateInstance<DirectoryResolver>(_serviceProvider);
        }

        public async Task ScaffoldServiceAsync(
            string areaName,
            string serviceName,
            object templateModel,
            bool force = false)
        {
            string directory = GetDirectoryInServices(areaName);
            string outputFileName = GetOutputFileName(directory, serviceName);
            await AddServicesFileAsync(outputFileName, "ServiceTemplate", templateModel);
        }

        public async Task ScaffoldReadDtoAsync(
            string areaName,
            string dtoName,
            object templateModel,
            bool force = false)
        {
            string directory = GetDirectoryInServices(areaName, "Models");
            string outputFileName = GetOutputFileName(directory, dtoName);
            await AddServicesFileAsync(outputFileName, "ReadDtoTemplate", templateModel);
        }

        #region Helpers

        private async Task AddServicesFileAsync(
            string outputFileName,
            string templateName,
            object templateModel,
            bool force = false)
        {
            ValidateOutputFileName(outputFileName, force);
            string templateFolder = _directoryResolver.GetTemplateFolder(ScaffoldType.Service);
            await _codeGeneratorActionsService.AddFileFromTemplateAsync(
                outputFileName, $"{templateName}.{TemplateFileExtension}", templateFolder, templateModel);
        }

        private string GetDirectoryInServices(params string[] paths)
        {
            string srcPath = Directory.GetParent(_applicationEnvironment.ApplicationBasePath).FullName;
            string directory = Path.Combine(srcPath, _nameResolver.GetServicesNamespace(), Path.Combine(paths));
            if (!Directory.Exists(directory))
            {
                _logger.LogMessage($"Directory {directory} did not exist, creating...");
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private string GetOutputFileName(string directory, string fileNameWithoutExtension)
        {
            return Path.Combine(directory, $"{fileNameWithoutExtension}.{CodeFileExtension}");
        }

        private void ValidateOutputFileName(string outputFileName, bool force = false)
        {
            if (File.Exists(outputFileName) && !force)
            {
                throw new InvalidOperationException($"The file {outputFileName} exists, use -f option to overwrite");
            }
        }

        #endregion
    }
}
