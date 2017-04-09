using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSMDbContext.Migrations
{
    public partial class db03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsers_Session_SessionId",
                table: "AdminUsers");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropIndex(
                name: "IX_AdminUsers_SessionId",
                table: "AdminUsers");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "AdminUsers");

            migrationBuilder.AddColumn<string>(
                name: "SessionKey",
                table: "AdminUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionKey",
                table: "AdminUsers");

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "AdminUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminUsers_SessionId",
                table: "AdminUsers",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsers_Session_SessionId",
                table: "AdminUsers",
                column: "SessionId",
                principalTable: "Session",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
