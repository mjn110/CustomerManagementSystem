using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Infrastructure.Data
{
    public class CustomerOrderManagementContext(DbContextOptions<CustomerOrderManagementContext> options) : IdentityDbContext<User>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Additional configuration if needed

            builder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.HasDefaultSchema("identity");

            builder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .ToTable("Products", schema: null)
                .HasKey(p => p.ProductId);

            builder.Entity<ProductItem>()
                .ToTable("ProductItems", schema: null)
                .HasKey(pi => pi.ProductItemId);

            builder.Entity<Product>()
                .HasMany(p => p.ProductItems)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }

    }
}
