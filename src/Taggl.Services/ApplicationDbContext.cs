using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Taggl.Framework.Models.Identity;
using Microsoft.Data.Entity;
using Taggl.Framework.Utility;
using Taggl.Framework.Models.Jobs;
using Taggl.Framework.Models.Professionals;

namespace Taggl.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUserRelationships> UserRelationships { get; set; }

        public DbSet<ApplicationUserStatus> UserStatuses { get; set; }

        public DbSet<JobTag> JobTags { get; set; }

        public DbSet<Professional> Professionals { get; set; }
        public DbSet<ProfessionalExpertise> ProfessionalExpertise { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<ApplicationUserStatus>().HasTableName(nameof(UserStatuses));

            builder.Entity<JobTag>().HasTableName(nameof(JobTags));

            builder.Entity<Professional>().HasTableName(nameof(Professionals));
            builder.Entity<ProfessionalExpertise>().HasTableName(nameof(ProfessionalExpertise));
        }
    }
}
