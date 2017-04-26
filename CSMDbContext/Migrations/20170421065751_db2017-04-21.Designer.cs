using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSMDbContext;

namespace CSMDbContext.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20170421065751_db2017-04-21")]
    partial class db20170421
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSMEntity.Entitys.AdminUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("SessionKey");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryOneId");

                    b.Property<string>("Icon");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name");

                    b.Property<string>("url");

                    b.HasKey("CategoryId");

                    b.HasIndex("CategoryOneId");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("CSMEntity.Entitys.CategoryOne", b =>
                {
                    b.Property<int>("CategoryOneId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Icon");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("Name");

                    b.Property<string>("url");

                    b.HasKey("CategoryOneId");

                    b.ToTable("CategoryOnes");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Cookbook", b =>
                {
                    b.Property<Guid>("CookbookId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<int>("Inventory");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("CookbookId");

                    b.ToTable("Cookbooks");
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookAndCategory", b =>
                {
                    b.Property<Guid>("CookbookId");

                    b.Property<int>("CategoryId");

                    b.HasKey("CookbookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CookbookAndCategory");
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookAndFood", b =>
                {
                    b.Property<Guid>("CookbookId");

                    b.Property<Guid>("FoodId");

                    b.Property<int>("Dose");

                    b.HasKey("CookbookId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("CookbookAndFood");
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookImages", b =>
                {
                    b.Property<int>("CookbookImagesId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CookbookId");

                    b.Property<string>("Describe");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("CookbookImagesId");

                    b.HasIndex("CookbookId");

                    b.ToTable("CookbookImages");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Food", b =>
                {
                    b.Property<Guid>("FoodId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<int>("Dose");

                    b.Property<DateTime>("Insertdate");

                    b.Property<int>("Inventory");

                    b.Property<int>("MinDose");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PurchasesDate");

                    b.Property<bool>("Shelves");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("CSMEntity.Entitys.FoodAndCategory", b =>
                {
                    b.Property<Guid>("FoodId");

                    b.Property<int>("CategoryId");

                    b.HasKey("FoodId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("FoodAndCategory");
                });

            modelBuilder.Entity("CSMEntity.Entitys.FoodImages", b =>
                {
                    b.Property<int>("FoodImagesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Describe");

                    b.Property<Guid>("FoodId");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("FoodImagesId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodImages");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Package", b =>
                {
                    b.Property<Guid>("PackageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Desc");

                    b.Property<int>("Inventory");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("PackageId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndCategory", b =>
                {
                    b.Property<Guid>("PackageId");

                    b.Property<int>("CategoryId");

                    b.HasKey("PackageId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PackageAndCategory");
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndCookbook", b =>
                {
                    b.Property<Guid>("PackageId");

                    b.Property<Guid>("CookbookId");

                    b.Property<int>("Dose");

                    b.HasKey("PackageId", "CookbookId");

                    b.HasIndex("CookbookId");

                    b.ToTable("PackageAndCookbook");
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndFood", b =>
                {
                    b.Property<Guid>("PackageId");

                    b.Property<Guid>("FoodId");

                    b.Property<int>("Dose");

                    b.HasKey("PackageId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("PackageAndFood");
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageImages", b =>
                {
                    b.Property<int>("PackageImagesId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Describe");

                    b.Property<Guid>("PackageId");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("PackageImagesId");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageImages");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Category", b =>
                {
                    b.HasOne("CSMEntity.Entitys.CategoryOne", "CategoryOne")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryOneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookAndCategory", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Category", "Category")
                        .WithMany("CookbookAndCategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Cookbook", "Cookbook")
                        .WithMany("CookbookAndCategorys")
                        .HasForeignKey("CookbookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookAndFood", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Cookbook", "Cookbook")
                        .WithMany("CookbookAndFoods")
                        .HasForeignKey("CookbookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Food", "Food")
                        .WithMany("CookbookAndFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.CookbookImages", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Cookbook", "Cookbook")
                        .WithMany()
                        .HasForeignKey("CookbookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.FoodAndCategory", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Category", "Category")
                        .WithMany("FoodAndCategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Food", "Food")
                        .WithMany("FoodAndCategorys")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.FoodImages", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Food", "Food")
                        .WithMany("FoodImages")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndCategory", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Category", "Category")
                        .WithMany("PackageAndCategorys")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Package", "Package")
                        .WithMany("PackageAndCategorys")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndCookbook", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Cookbook", "Cookbook")
                        .WithMany("PackageAndCookbooks")
                        .HasForeignKey("CookbookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Package", "Package")
                        .WithMany("PackageAndCookbooks")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageAndFood", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Food", "Food")
                        .WithMany("PackageAndFoods")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CSMEntity.Entitys.Package", "Package")
                        .WithMany("PackageAndFoods")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CSMEntity.Entitys.PackageImages", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
