using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CSMEntity.Entitys;

namespace CSMDbContext
{
     public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base(options)
        {

        }
        /// <summary>
        /// 第三张表设置
        /// </summary>
        /// <param name="ModelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            /* Food **************************************************************/
            // 分类
            ModelBuilder.Entity<FoodAndCategory>()
                .HasKey(f => new { f.FoodId, f.CategoryId });
            ModelBuilder.Entity<FoodAndCategory>()
                .HasOne(fc => fc.Food)
                .WithMany(f => f.FoodAndCategorys )
                .HasForeignKey(fc => fc.FoodId);
            ModelBuilder.Entity<FoodAndCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(f => f.FoodAndCategorys)
                .HasForeignKey(fc => fc.CategoryId);
            /* Food **************************************************************/
            /* cookbook **************************************************************/
            // 分类
            ModelBuilder.Entity<CookbookAndCategory>()
                .HasKey(f => new { f.CookbookId, f.CategoryId });
            ModelBuilder.Entity<CookbookAndCategory>()
                .HasOne(fc => fc.Cookbook)
                .WithMany(f => f.CookbookAndCategorys)
                .HasForeignKey(fc => fc.CookbookId);
            ModelBuilder.Entity<CookbookAndCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(f => f.CookbookAndCategorys)
                .HasForeignKey(fc => fc.CategoryId);
            // 食材
            ModelBuilder.Entity<CookbookAndFood>()
                .HasKey(f => new { f.CookbookId, f.FoodId });
            ModelBuilder.Entity<CookbookAndFood>()
                .HasOne(fc => fc.Cookbook)
                .WithMany(f => f.CookbookAndFoods)
                .HasForeignKey(fc => fc.CookbookId);
            ModelBuilder.Entity<CookbookAndFood>()
                .HasOne(fc => fc.Food)
                .WithMany(f => f.CookbookAndFoods)
                .HasForeignKey(fc => fc.FoodId);
            /* Cookbook **************************************************************/
            /* Package **************************************************************/
            //分类
            ModelBuilder.Entity<PackageAndCategory>()
                .HasKey(f => new { f.PackageId, f.CategoryId });
            ModelBuilder.Entity<PackageAndCategory>()
                .HasOne(fc => fc.Package)
                .WithMany(f => f.PackageAndCategorys)
                .HasForeignKey(fc => fc.PackageId);
            ModelBuilder.Entity<PackageAndCategory>()
                .HasOne(fc => fc.Category)
                .WithMany(f => f.PackageAndCategorys)
                .HasForeignKey(fc => fc.CategoryId);
            // 菜谱
            ModelBuilder.Entity<PackageAndCookbook>()
                .HasKey(f => new { f.PackageId, f.CookbookId });
            ModelBuilder.Entity<PackageAndCookbook>()
                .HasOne(fc => fc.Package)
                .WithMany(f => f.PackageAndCookbooks)
                .HasForeignKey(fc => fc.PackageId);
            ModelBuilder.Entity<PackageAndCookbook>()
                .HasOne(fc => fc.Cookbook)
                .WithMany(f => f.PackageAndCookbooks)
                .HasForeignKey(fc => fc.CookbookId);
            // 食材
            ModelBuilder.Entity<PackageAndFood>()
                .HasKey(f => new { f.PackageId, f.FoodId });
            ModelBuilder.Entity<PackageAndFood>()
                .HasOne(fc => fc.Package)
                .WithMany(f => f.PackageAndFoods)
                .HasForeignKey(fc => fc.PackageId);
            ModelBuilder.Entity<PackageAndFood>()
                .HasOne(fc => fc.Food)
                .WithMany(f => f.PackageAndFoods)
                .HasForeignKey(fc => fc.FoodId);
            /* Package **************************************************************/
        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CategoryOne> CategoryOnes { get; set; }

        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodImages> FoodImages { get; set; }

        public DbSet<Cookbook> Cookbooks { get; set; }
        public DbSet<CookbookImages> CookbookImages { get; set; }

        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageImages> PackageImages { get; set; }
    }
}
