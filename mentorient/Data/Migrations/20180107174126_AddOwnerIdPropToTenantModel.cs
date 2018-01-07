using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorient.Data.Migrations
{
    public partial class AddOwnerIdPropToTenantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Tenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Tenants");
        }
    }
}
