using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Taggl.Services.Migrations
{
    public partial class Add_ShiftType_ColorSwitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId", table: "AspNetRoleClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserClaim<string>_ApplicationUser_UserId", table: "AspNetUserClaims");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserLogin<string>_ApplicationUser_UserId", table: "AspNetUserLogins");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_IdentityRole_RoleId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_IdentityUserRole<string>_ApplicationUser_UserId", table: "AspNetUserRoles");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId", table: "UserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId", table: "UserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_Professionality_ProfessionalityId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_ShiftType_ShiftTypeId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_ShiftSchedule_Gym_GymId", table: "ShiftSchedules");
            migrationBuilder.DropForeignKey(name: "FK_ShiftSchedule_ShiftType_ShiftTypeId", table: "ShiftSchedules");
            migrationBuilder.DropColumn(name: "ColorSwitch", table: "ShiftSchedules");
            migrationBuilder.AddColumn<int>(
                name: "ColorSwitch",
                table: "ShiftTypes",
                nullable: false,
                defaultValue: 1);
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
                table: "UserRelationships",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId",
                table: "UserRelationships",
                column: "StatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Professionality_ProfessionalityId",
                table: "Expertise",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_ShiftType_ShiftTypeId",
                table: "Expertise",
                column: "ShiftTypeId",
                principalTable: "ShiftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ShiftSchedule_Gym_GymId",
                table: "ShiftSchedules",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_ShiftSchedule_ShiftType_ShiftTypeId",
                table: "ShiftSchedules",
                column: "ShiftTypeId",
                principalTable: "ShiftTypes",
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
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_Professionality_ProfessionalityId", table: "UserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId", table: "UserRelationships");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_Professionality_ProfessionalityId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_Expertise_ShiftType_ShiftTypeId", table: "Expertise");
            migrationBuilder.DropForeignKey(name: "FK_ShiftSchedule_Gym_GymId", table: "ShiftSchedules");
            migrationBuilder.DropForeignKey(name: "FK_ShiftSchedule_ShiftType_ShiftTypeId", table: "ShiftSchedules");
            migrationBuilder.DropColumn(name: "ColorSwitch", table: "ShiftTypes");
            migrationBuilder.AddColumn<int>(
                name: "ColorSwitch",
                table: "ShiftSchedules",
                nullable: false,
                defaultValue: 0);
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
                table: "UserRelationships",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRelationships_ApplicationUserStatus_StatusId",
                table: "UserRelationships",
                column: "StatusId",
                principalTable: "UserStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_Professionality_ProfessionalityId",
                table: "Expertise",
                column: "ProfessionalityId",
                principalTable: "Professionalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Expertise_ShiftType_ShiftTypeId",
                table: "Expertise",
                column: "ShiftTypeId",
                principalTable: "ShiftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ShiftSchedule_Gym_GymId",
                table: "ShiftSchedules",
                column: "GymId",
                principalTable: "Gyms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_ShiftSchedule_ShiftType_ShiftTypeId",
                table: "ShiftSchedules",
                column: "ShiftTypeId",
                principalTable: "ShiftTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
