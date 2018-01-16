using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorient.Data.Migrations
{
    public partial class EntriesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_TenantId",
                table: "Entries",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_Tenants_TenantId",
                table: "Entries",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_Tenants_TenantId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_TenantId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Entries");
        }
    }
}
