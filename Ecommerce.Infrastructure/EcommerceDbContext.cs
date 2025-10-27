using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class EcommerceDbContext : DbContext, IEcommerceDbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired();
                entity.Property(c => c.Name).IsRequired();
                entity.HasMany(c => c.Orders)
                      .WithOne(c => c.Customer)
                      .HasForeignKey(c => c.CustomerId);
            });

            // Order
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);
                entity.Property(o => o.Total).HasColumnType("decimal(18,2)");
                entity.Property(o => o.CreatedAt).IsRequired();
                entity.HasMany(o => o.Items)
                      .WithOne(i => i.Order)
                      .HasForeignKey(i => i.OrderId);
            });

            // Product
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Stock).HasDefaultValue(0);
                entity.HasMany(p => p.OrderItems)
                      .WithOne(i => i.Product)
                      .HasForeignKey(i => i.ProductId);
            });

            // OrderItem
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Price).HasColumnType("decimal(18,2)");
                entity.Property(i => i.Quantity).IsRequired();
            });
        }
    }
}