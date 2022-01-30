using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpotzerMediaPro.Domain.Entities;

namespace SpotzerMediaPro.Domain.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Noop
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Channel> Channels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Here we create the indexes for each entity manually
            modelBuilder.Entity<Product>().HasIndex(u => new { u.ProductId });
            modelBuilder.Entity<Channel>().HasIndex(u => new { u.Id });


            // Using a Value Converter so we can store the enums as strings in the database (https://docs.microsoft.com/en-us/ef/core/modeling/value-conversions)
            modelBuilder
                .Entity<Product>()
                .Property(m => m.ProductType)
                .HasConversion(new EnumToStringConverter<ProductType>());

        }
    }
}
