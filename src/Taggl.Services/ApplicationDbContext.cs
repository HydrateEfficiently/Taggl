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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUserRelationships> ApplicationUserRelationships { get; set; }
        public DbSet<ApplicationUserStatus> UserStatuses { get; set; }

        public DbSet<Gym> Gyms { get; set; }
        
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<ShiftSchedule> ShiftSchedules { get; set; }

        public DbSet<Professionality> Professionalities { get; set; }
        public DbSet<Expertise> Expertise { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRelationships>().HasTableName(nameof(ApplicationUserRelationships));
            builder.Entity<ApplicationUserStatus>().HasTableName(nameof(UserStatuses));

            //builder.Entity<Shift>().HasTableName(nameof(Shift));
            builder.Entity<ShiftType>().HasTableName(nameof(ShiftTypes));
            builder.Entity<ShiftSchedule>().HasTableName(nameof(ShiftSchedules));

            builder.Entity<Professionality>().HasTableName(nameof(Professionalities));
            builder.Entity<Expertise>().HasTableName(nameof(Expertise));
        }
    }
}
