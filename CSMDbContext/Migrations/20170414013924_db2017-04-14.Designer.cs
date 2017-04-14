using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSMDbContext;

namespace CSMDbContext.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20170414013924_db2017-04-14")]
    partial class db20170414
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

            modelBuilder.Entity("CSMEntity.Entitys.Category", b =>
                {
                    b.HasOne("CSMEntity.Entitys.CategoryOne", "CategoryOne")
                        .WithMany("SubCategory")
                        .HasForeignKey("CategoryOneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
