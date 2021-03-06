﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Taggl.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Taggl.Initializer.Services;
using Taggl.Framework.Services;
using Taggl.Initializer.Initializers;
using Taggl.Initializer.Initializers.Identity;
using Taggl.Initializer.Services.DataImportServices;
using Taggl.Initializer.Services.Framework;
using Taggl.Initializer.Initializers.Environments;
using Taggl.Initializer.Initializers.Professionalities;
using Taggl.Initializer.Initializers.Shifts;

namespace Taggl.Initializer
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment hostingEnv)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{hostingEnv.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices(connectionString: Configuration["Data:DefaultConnection:ConnectionString"]);

            // Framework Services
            services.AddTransient<IEmailService, StubbedEmailService>();
            services.AddTransient<IIdentityResolver, SystemUserIdentityResolver>();
            services.AddTransient<IUrlResolver, StubbedUrlResolver>();

            // Services
            services.AddTransient<JsonDataImportService>();

            services.AddInitializer<RoleInitializer>();
            services.AddInitializer<SystemUserInitializer>();
            services.AddInitializer<AdministratorsInitializer>();
            services.AddInitializer<ShiftTypeInitializer>();
            //services.AddInitializer<ExpertiseInitializer>();

            services.AddTransient<IEnvironmentInitializer, DebugEnvironmentInitializer>();
            services.AddTransient<RootDataInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IServiceProvider serviceProvider)
        {
            var initializer = serviceProvider.GetRequiredService<RootDataInitializer>();
            initializer.Run();
            Environment.Exit(0);
        }

        // Entry point for the application.
        public static void Main(string[] args) { }
    }
}
