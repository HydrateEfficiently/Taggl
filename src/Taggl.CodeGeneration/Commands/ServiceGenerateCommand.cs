using AutoMapper;
using Microsoft.Extensions.CodeGeneration.CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Commands.Models;
using Taggl.CodeGeneration.Generators.Dto;
using Taggl.CodeGeneration.Generators.DtoMappings;
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

            var dtoGenerator = GetGenerator<DtoGenerator>(new DtoCommandLineModel()
            {
                Force = model.Force,
                Read = true,
                Create = true,
                Update = true,
                Entity = model.Entity
            });
            scaffoldingTasks.Add(dtoGenerator.Generate());

            var dtoMappingsGenerator = GetGenerator<DtoMappingsGenerator>(new FromEntityCommandLineModel()
            {
                Force = model.Force,
                Entity = model.Entity
            });
            scaffoldingTasks.Add(dtoMappingsGenerator.Generate());

            await Task.WhenAll(scaffoldingTasks);
        }
    }
}
