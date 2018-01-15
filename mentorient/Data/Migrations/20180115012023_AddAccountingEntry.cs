using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mentorient.Data.Migrations
{
    public partial class AddAccountingEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Entries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entries_ApplicationUserId",
                table: "Entries",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entries_AspNetUsers_ApplicationUserId",
                table: "Entries");

            migrationBuilder.DropIndex(
                name: "IX_Entries_ApplicationUserId",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Entries");
        }
    }
}
