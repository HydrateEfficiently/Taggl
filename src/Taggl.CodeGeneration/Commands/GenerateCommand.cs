﻿using Microsoft.Dnx.Compilation;
using Microsoft.Extensions.CodeGeneration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.CodeGeneration.Generators;
using Taggl.CodeGeneration.Services;
using Taggl.CodeGeneration.Utility;

namespace Taggl.CodeGeneration.Commands
{
    public abstract class GenerateCommand : ICodeGenerator
    {
        protected readonly ServiceProvider _serviceProvider;

        public GenerateCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = new ServiceProvider(serviceProvider);

            AddService(PlatformServices.Default.Application);
            AddService(PlatformServices.Default.Runtime);
            AddService(PlatformServices.Default.AssemblyLoadContextAccessor);
            AddService(PlatformServices.Default.AssemblyLoaderContainer);
            AddService(PlatformServices.Default.LibraryManager);
            AddService(CompilationServices.Default.LibraryExporter);
            AddService(CompilationServices.Default.CompilerOptionsProvider);

            AddService(new OutputClassNameResolver());
            AddServiceWithDependency<NamespaceService, NamespaceService>();
            AddServiceWithDependency<ScaffoldingService, ScaffoldingService>();

        }

        protected TGenerator GetGenerator<TGenerator>(CommandLineModel commandLineModel) where TGenerator : IGenerator
        {
            return ActivatorUtilities.CreateInstance<TGenerator>(_serviceProvider, commandLineModel);
        }
        
        protected TService GetService<TService>()
        {
            return _serviceProvider.GetRequiredService<TService>();
        }

        protected void AddServiceWithDependency<TService, TImplementation>()
        {
            _serviceProvider.AddServiceWithDependencies<TService, TImplementation>();
        }

        protected void AddService<TService>(TService instance)
        {
            _serviceProvider.Add(typeof(TService), instance);
        }
    }
}