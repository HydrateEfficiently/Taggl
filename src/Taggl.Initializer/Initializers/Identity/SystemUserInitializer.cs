using Microsoft.AspNet.Identity;
using Taggl.Framework.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;

namespace Taggl.Initializer.Initializers.Identity
{
    public class SystemUserInitializer : IDataInitializer
    {
        private const string SystemUserEmail = "system@noreply.com";

        private readonly UserManager<ApplicationUser> _userManager;

        public SystemUserInitializer(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void Run()
        {
            GetUser();
        }

        public ApplicationUser GetUser()
        {
            var user = _userManager.FindByEmailAsync(SystemUserEmail).Result;
            if (user == null)
            {
                _userManager.CreateAsync(new ApplicationUser()
                {
                    UserName = "SYSTEM-USER",
                    Email = SystemUserEmail
                }).Wait();
                user = _userManager.FindByEmailAsync(SystemUserEmail).Result;
            }

            if (!_userManager.IsInRoleAsync(user, ApplicationRoles.Administrator).Result)
            {
                _userManager.AddToRoleAsync(user, ApplicationRoles.Administrator).Wait();
            }

            return user;
        }
    }
}
