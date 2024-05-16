using Microsoft.EntityFrameworkCore;
using PizzaShopAPI.models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PizzaShopAPI.context
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-QL1TE6V\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbPizzaShopAPI;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pizza>().HasData(new Pizza() { PId = 101, Name = "Chilli Cheese Pizza", Description = "Spicy With Loaded Cheese", Price = 100, Quantity = 10 },
                new Pizza() { PId = 102, Name = "Panner Cheese Pizza", Description = "Panner With Loaded Cheese", Price = 200, Quantity = 0 });

            modelBuilder.Entity<Customer>().HasKey(c => c.CId);
            modelBuilder.Entity<Order>().HasKey(o => o.OId);
            modelBuilder.Entity<OrderDetail>().HasKey(od => od.OdId);
            modelBuilder.Entity<Pizza>().HasKey(p => p.PId);

            modelBuilder.Entity<Customer>().HasMany(c => c.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            modelBuilder.Entity<Order>().HasMany(o => o.OrderDetails).WithOne(od => od.Order).HasForeignKey(od => od.OId).OnDelete(DeleteBehavior.Restrict).IsRequired();
            modelBuilder.Entity<Pizza>().HasMany(p => p.OrderDetails).WithOne(od => od.Pizza).HasForeignKey(od => od.PId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }

    }
}
