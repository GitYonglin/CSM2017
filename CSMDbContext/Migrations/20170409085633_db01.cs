using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSMDbContext.Migrations
{
    public partial class db01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Inserted",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "LoginTimes",
                table: "AdminUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Inserted",
                table: "AdminUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "AdminUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "AdminUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LoginTimes",
                table: "AdminUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
