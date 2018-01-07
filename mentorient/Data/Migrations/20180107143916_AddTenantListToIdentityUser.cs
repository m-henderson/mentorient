using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorient.Data.Migrations
{
    public partial class AddTenantListToIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Tenants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApplicationUserId",
                table: "Tenants",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AspNetUsers_ApplicationUserId",
                table: "Tenants",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AspNetUsers_ApplicationUserId",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_ApplicationUserId",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Tenants");
        }
    }
}
