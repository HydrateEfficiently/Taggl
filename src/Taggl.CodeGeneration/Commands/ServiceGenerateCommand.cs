using AutoMapper;
using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Generators.DtoMappings;
using Taggl.CodeGeneration.Generators.ReadDto;
using Taggl.CodeGeneration.Generators.Service;

namespace Taggl.CodeGeneration.Commands
{
    [Alias("service")]
    public class ServiceGenerateCommand : FromEntityGenerateCommand
    {
        private const string ServiceSuffix = "Service";

        public ServiceGenerateCommand(
            IServiceProvider serviceProvider)
            : base(serviceProvider)
        { }

        public async Task GenerateCode(ServiceCommandLineModel model)
        {
            ValidateCommandLineModel(model);

            var scaffoldingTasks = new List<Task>();

            var serviceGenerator = GetGenerator<ServiceGenerator>(model);
            scaffoldingTasks.Add(serviceGenerator.Generate());

            Mapper.CreateMap<ServiceCommandLineModel, EntityGenerateCommandLineModel>();
            var sideGeneratorModel = Mapper.Map<ServiceCommandLineModel, EntityGenerateCommandLineModel>(model);

            var readDtoGenerator = GetGenerator<ReadDtoGenerator>(sideGeneratorModel);
            scaffoldingTasks.Add(readDtoGenerator.Generate());

            var dtoMappingsGenerator = GetGenerator<DtoMappingsGenerator>(sideGeneratorModel);
            scaffoldingTasks.Add(dtoMappingsGenerator.Generate());

            await Task.WhenAll(scaffoldingTasks);
        }
    }
}
