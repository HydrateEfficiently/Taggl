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
using Taggl.Framework.Models.Vehicle;
using Taggl.Framework.Utility;

namespace Taggl.Services
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
        public DbSet<ApplicationUserRelationships> UserRelationships { get; set; }
        
        public DbSet<ApplicationUserStatus> UserStatuses { get; set; }
        
        public DbSet<Car> Cars { get; set; }
        
        public DbSet<Expertise> Expertise { get; set; }
        
        public DbSet<Gym> Gyms { get; set; }
        
        public DbSet<Professionality> Professionalities { get; set; }
        
        public DbSet<ShiftSchedule> ShiftSchedules { get; set; }
        
        public DbSet<ShiftType> ShiftTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserRelationships>().HasTableName(nameof(UserRelationships));
            builder.Entity<ApplicationUserStatus>().HasTableName(nameof(UserStatuses));
            builder.Entity<Car>().HasTableName(nameof(Cars));
            builder.Entity<Expertise>().HasTableName(nameof(Expertise));
            builder.Entity<Gym>().HasTableName(nameof(Gyms));
            builder.Entity<Professionality>().HasTableName(nameof(Professionalities));
            builder.Entity<ShiftSchedule>().HasTableName(nameof(ShiftSchedules));
            builder.Entity<ShiftType>().HasTableName(nameof(ShiftTypes));

            CustomOnModelCreating(builder);
        }
    }
}
