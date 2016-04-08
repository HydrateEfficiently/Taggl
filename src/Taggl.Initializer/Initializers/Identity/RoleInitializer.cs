using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Constants;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Utility;

namespace Taggl.Initializer.Initializers.Identity
{
    public class RoleInitializer : IDataInitializer
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleInitializer(
           RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void Run()
        {
            foreach (string role in typeof(ApplicationRoles).GetConstantsValues<string>())
            {
                if (_roleManager.FindByNameAsync(role).Result == null)
                {
                    _roleManager.CreateAsync(new IdentityRole() { Name = role }).Wait();
                }
            }
        }
    }
}
