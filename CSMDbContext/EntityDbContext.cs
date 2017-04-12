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

        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<CategoryOne> CategoryOnes { get; set; }
    }
}
