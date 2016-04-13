using Microsoft.Data.Entity;
using Taggl.Initializer.Initializers.Identity;
using Taggl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Initializer.Initializers.Environments;
using Taggl.Framework.Utility;
using Microsoft.Extensions.DependencyInjection;

namespace Taggl.Initializer.Initializers
{
    public class RootDataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEnvironmentInitializer _environmentInitializer;
        private readonly IServiceProvider _serviceProvider;

        public RootDataInitializer(
            ApplicationDbContext dbContext,
            IEnvironmentInitializer environmentInitializer,
            IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _environmentInitializer = environmentInitializer;
            _serviceProvider = serviceProvider;
        }

        public void Run()
        {
            _dbContext.Database.Migrate();

            InitializerRepository.GetInitializers()
                .ForEach(t =>
                {
                    var initializer = _serviceProvider.GetRequiredService(t) as IDataInitializer;
                    initializer.Run();
                });

            _environmentInitializer.Run();
        }
    }
}
