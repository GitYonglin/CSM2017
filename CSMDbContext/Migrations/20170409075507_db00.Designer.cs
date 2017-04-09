using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CSMDbContext;

namespace CSMDbContext.Migrations
{
    [DbContext(typeof(EntityDbContext))]
    [Migration("20170409075507_db00")]
    partial class db00
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

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastLoginTime");

                    b.Property<DateTime>("LastUpdated")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("LoginTimes");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int?>("SessionId");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("CSMEntity.Entitys.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Key");

                    b.HasKey("Id");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("CSMEntity.Entitys.AdminUser", b =>
                {
                    b.HasOne("CSMEntity.Entitys.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");
                });
        }
    }
}
