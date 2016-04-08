using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Taggl.Framework.Models.Identity;
using Microsoft.Data.Entity;
using Taggl.Framework.Utility;

namespace Taggl.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<ApplicationUserStatus> ApplicationUserStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserStatus>().HasTableName(nameof(ApplicationUserStatuses));
        }
    }
}
