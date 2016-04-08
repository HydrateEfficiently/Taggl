using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Taggl.Framework.Models.Identity;
using Taggl.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Services.Administrator;

namespace Taggl.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(
            this IServiceCollection services,
            string connectionString,
            string loginPath = null)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                if (loginPath != null)
                {
                    options.Cookies.ApplicationCookie.LoginPath = loginPath;
                }
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            // Administration
            services.AddTransient<IAdministrationService, AdministrationService>();

            // Identity
            services.AddScoped<SignInManager<ApplicationUser>, ApplicationSignInManager>();
            services.AddTransient<IRegistrationService, RegistrationService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICurrentUserProvider, CurrentUserProvider>();
            services.AddTransient<IUserStatusResolver, UserStatusResolver>();
            services.AddTransient<IUserSearchService, UserSearchService>();
        }
    }
}
