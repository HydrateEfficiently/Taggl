using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Taggl.Services.Migrations
{
    public partial class AddAuditing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId", table: "ApplicationUserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId", table: "ApplicationUserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_JobTag_JobTagId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_Professionality_ProfessionalityId", table: "Expertise");
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Expertise",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Expertise",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId",
                table: "ApplicationUserRelationships",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId",
                table: "ApplicationUserRelationships",
                column: "StatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_ApplicationUser_DeletedById",
                table: "Expertise",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_JobTag_JobTagId",
                table: "Expertise",
                column: "JobTagId",
                principalTable: "JobTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Professionality_ProfessionalityId",
                table: "Expertise",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId", table: "ApplicationUserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId", table: "ApplicationUserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_ApplicationUser_DeletedById", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_JobTag_JobTagId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_Professionality_ProfessionalityId", table: "Expertise");
            migrationBuilder.DropColumn(name: "Deleted", table: "Expertise");
            migrationBuilder.DropColumn(name: "DeletedById", table: "Expertise");
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_ApplicationUser_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId",
                table: "ApplicationUserRelationships",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId",
                table: "ApplicationUserRelationships",
                column: "StatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_JobTag_JobTagId",
                table: "Expertise",
                column: "JobTagId",
                principalTable: "JobTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Professionality_ProfessionalityId",
                table: "Expertise",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
