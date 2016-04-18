using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Taggl.Framework.Models.Identity;
using Microsoft.Data.Entity;
using Taggl.Framework.Utility;
using Taggl.Framework.Models.Shifts;
using Taggl.Framework.Models.Professionalities;

namespace Taggl.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUserRelationships> ApplicationUserRelationships { get; set; }
        public DbSet<ApplicationUserStatus> UserStatuses { get; set; }

        public DbSet<ShiftType> ShiftTypes { get; set; }

        public DbSet<Professionality> Professionalities { get; set; }
        public DbSet<Expertise> Expertise { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRelationships>().HasTableName(nameof(ApplicationUserRelationships));
            builder.Entity<ApplicationUserStatus>().HasTableName(nameof(UserStatuses));

            builder.Entity<ShiftType>().HasTableName(nameof(ShiftTypes));

            builder.Entity<Professionality>().HasTableName(nameof(Professionalities));
            builder.Entity<Expertise>().HasTableName(nameof(Expertise));
        }
    }
}
