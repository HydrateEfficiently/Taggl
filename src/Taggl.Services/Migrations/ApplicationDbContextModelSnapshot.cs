using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Taggl.Services;

namespace Taggl.Services.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Gyms.Gym", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedById");

                    b.Property<bool>("IsSearchable");

                    b.Property<string>("Name");

                    b.Property<string>("NameNormalized");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Gyms");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Identity.ApplicationUserRelationships", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ProfessionalityId");

                    b.Property<Guid>("StatusId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "UserRelationships");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Identity.ApplicationUserStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("Approved");

                    b.Property<string>("ApprovedById");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "UserStatuses");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Professionalities.Expertise", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedById");

                    b.Property<Guid>("ProfessionalityId");

                    b.Property<Guid>("ShiftTypeId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Expertise");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Professionalities.Professionality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Professionalities");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Shifts.ShiftSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedById");

                    b.Property<DateTime?>("Deleted");

                    b.Property<string>("DeletedById");

                    b.Property<TimeSpan>("Duration");

                    b.Property<DateTime>("FromDate");

                    b.Property<Guid>("GymId");

                    b.Property<Guid>("ShiftTypeId");

                    b.Property<DateTime>("Updated");

                    b.Property<string>("UpdatedById");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "ShiftSchedules");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Shifts.ShiftType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ColorSwitch");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedById");

                    b.Property<bool>("IsSearchable");

                    b.Property<string>("Name");

                    b.Property<string>("NameNormalized");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "ShiftTypes");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Gyms.Gym", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Identity.ApplicationUserRelationships", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Professionalities.Professionality")
                        .WithMany()
                        .HasForeignKey("ProfessionalityId");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUserStatus")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Identity.ApplicationUserStatus", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApprovedById");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Professionalities.Expertise", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("Taggl.Framework.Models.Professionalities.Professionality")
                        .WithMany()
                        .HasForeignKey("ProfessionalityId");

                    b.HasOne("Taggl.Framework.Models.Shifts.ShiftType")
                        .WithMany()
                        .HasForeignKey("ShiftTypeId");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Shifts.ShiftSchedule", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("DeletedById");

                    b.HasOne("Taggl.Framework.Models.Gyms.Gym")
                        .WithMany()
                        .HasForeignKey("GymId");

                    b.HasOne("Taggl.Framework.Models.Shifts.ShiftType")
                        .WithMany()
                        .HasForeignKey("ShiftTypeId");

                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UpdatedById");
                });

            modelBuilder.Entity("Taggl.Framework.Models.Shifts.ShiftType", b =>
                {
                    b.HasOne("Taggl.Framework.Models.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("CreatedById");
                });
        }
    }
}
