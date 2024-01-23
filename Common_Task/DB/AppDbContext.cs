using Common_Task.Models;
using Microsoft.EntityFrameworkCore;

namespace Common_Task.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ConfigurationItem> ConfigurationItems => Set<ConfigurationItem>();

        ////protected override void OnModelCreating(ModelBuilder modelBuilder)
        ////{
        ////    base.OnModelCreating(modelBuilder);

        ////    modelBuilder.Entity<ConfigurationItem>().HasData(new ConfigurationItem
        ////    {
        ////        Id = 1,
        ////        Key = "#####",
        ////        Value = "value",
        ////        ParentId = 1,

        ////    });
        ////}
    }
}
