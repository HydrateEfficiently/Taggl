﻿using Microsoft.Data.Entity;
using Taggl.Initializer.Initializers.Identity;
using Taggl.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taggl.Initializer.Initializers
{
    public class MainDataInitializer : IDataInitializer
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly SystemUserInitializer _systemUserInitializer;
        private readonly IEnvironmentInitializer _environmentInitializer;

        public MainDataInitializer(
            ApplicationDbContext dbContext,
            SystemUserInitializer systemUserInitializer,
            IEnvironmentInitializer environmentInitializer)
        {
            _dbContext = dbContext;
            _systemUserInitializer = systemUserInitializer;
            _environmentInitializer = environmentInitializer;
        }

        public void Run()
        {
            _dbContext.Database.Migrate();

            // Identity
            _systemUserInitializer.Run();

            _environmentInitializer.Run();
        }
    }
}
