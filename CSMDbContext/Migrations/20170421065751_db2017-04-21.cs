using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CSMDbContext.Migrations
{
    public partial class db20170421 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    SessionKey = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryOnes",
                columns: table => new
                {
                    CategoryOneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Icon = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryOnes", x => x.CategoryOneId);
                });

            migrationBuilder.CreateTable(
                name: "Cookbooks",
                columns: table => new
                {
                    CookbookId = table.Column<Guid>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Inventory = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cookbooks", x => x.CookbookId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Dose = table.Column<int>(nullable: false),
                    Insertdate = table.Column<DateTime>(nullable: false),
                    Inventory = table.Column<int>(nullable: false),
                    MinDose = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    PurchasesDate = table.Column<DateTime>(nullable: false),
                    Shelves = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    Inventory = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.PackageId);
                });

            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryOneId = table.Column<int>(nullable: false),
                    Icon = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categorys_CategoryOnes_CategoryOneId",
                        column: x => x.CategoryOneId,
                        principalTable: "CategoryOnes",
                        principalColumn: "CategoryOneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookbookImages",
                columns: table => new
                {
                    CookbookImagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CookbookId = table.Column<Guid>(nullable: false),
                    Describe = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookbookImages", x => x.CookbookImagesId);
                    table.ForeignKey(
                        name: "FK_CookbookImages_Cookbooks_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbooks",
                        principalColumn: "CookbookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookbookAndFood",
                columns: table => new
                {
                    CookbookId = table.Column<Guid>(nullable: false),
                    FoodId = table.Column<Guid>(nullable: false),
                    Dose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookbookAndFood", x => new { x.CookbookId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_CookbookAndFood_Cookbooks_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbooks",
                        principalColumn: "CookbookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookbookAndFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodImages",
                columns: table => new
                {
                    FoodImagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Describe = table.Column<string>(nullable: true),
                    FoodId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodImages", x => x.FoodImagesId);
                    table.ForeignKey(
                        name: "FK_FoodImages_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageAndCookbook",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(nullable: false),
                    CookbookId = table.Column<Guid>(nullable: false),
                    Dose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAndCookbook", x => new { x.PackageId, x.CookbookId });
                    table.ForeignKey(
                        name: "FK_PackageAndCookbook_Cookbooks_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbooks",
                        principalColumn: "CookbookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageAndCookbook_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageAndFood",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(nullable: false),
                    FoodId = table.Column<Guid>(nullable: false),
                    Dose = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAndFood", x => new { x.PackageId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_PackageAndFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageAndFood_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageImages",
                columns: table => new
                {
                    PackageImagesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Describe = table.Column<string>(nullable: true),
                    PackageId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageImages", x => x.PackageImagesId);
                    table.ForeignKey(
                        name: "FK_PackageImages_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookbookAndCategory",
                columns: table => new
                {
                    CookbookId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookbookAndCategory", x => new { x.CookbookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CookbookAndCategory_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookbookAndCategory_Cookbooks_CookbookId",
                        column: x => x.CookbookId,
                        principalTable: "Cookbooks",
                        principalColumn: "CookbookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodAndCategory",
                columns: table => new
                {
                    FoodId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodAndCategory", x => new { x.FoodId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_FoodAndCategory_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodAndCategory_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageAndCategory",
                columns: table => new
                {
                    PackageId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageAndCategory", x => new { x.PackageId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_PackageAndCategory_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageAndCategory_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "PackageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorys_CategoryOneId",
                table: "Categorys",
                column: "CategoryOneId");

            migrationBuilder.CreateIndex(
                name: "IX_CookbookAndCategory_CategoryId",
                table: "CookbookAndCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CookbookAndFood_FoodId",
                table: "CookbookAndFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_CookbookImages_CookbookId",
                table: "CookbookImages",
                column: "CookbookId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodAndCategory_CategoryId",
                table: "FoodAndCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodImages_FoodId",
                table: "FoodImages",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAndCategory_CategoryId",
                table: "PackageAndCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAndCookbook_CookbookId",
                table: "PackageAndCookbook",
                column: "CookbookId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageAndFood_FoodId",
                table: "PackageAndFood",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageImages_PackageId",
                table: "PackageImages",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "CookbookAndCategory");

            migrationBuilder.DropTable(
                name: "CookbookAndFood");

            migrationBuilder.DropTable(
                name: "CookbookImages");

            migrationBuilder.DropTable(
                name: "FoodAndCategory");

            migrationBuilder.DropTable(
                name: "FoodImages");

            migrationBuilder.DropTable(
                name: "PackageAndCategory");

            migrationBuilder.DropTable(
                name: "PackageAndCookbook");

            migrationBuilder.DropTable(
                name: "PackageAndFood");

            migrationBuilder.DropTable(
                name: "PackageImages");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Cookbooks");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "CategoryOnes");
        }
    }
}
