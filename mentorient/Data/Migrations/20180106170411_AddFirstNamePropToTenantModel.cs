using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorient.Data.Migrations
{
    public partial class AddFirstNamePropToTenantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Tenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Tenants");
        }
    }
}
