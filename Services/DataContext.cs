using ChipsetShop.MVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChipsetShop.MVC.Services
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<AttributeScemeModel> AttributeScemes { get; set; }
        public DbSet<AttributeModel> Attributes { get; set; }
        public DbSet<ImageStorageModel> ImageStorages { get; set; }

        public DataContext(IConfiguration configuration)
        {
            this.configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("Default"));
        }
    }
}
