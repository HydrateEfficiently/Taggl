using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taggl.Framework.Models.Gyms;
using Taggl.Framework.Models.Identity;
using Taggl.Framework.Models.Professionalities;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Utility;

namespace Taggl.Services
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private void CustomOnModelCreating(ModelBuilder builder)
        {
        }
    }
}