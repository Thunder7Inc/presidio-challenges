using Microsoft.EntityFrameworkCore;
using PizzaShopAPIJWT.model;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PizzaShopAPIJWT.context
{
    public class PizzaShopContext : DbContext

    {
        public PizzaShopContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 101, Name = "Arvind", Phone = "9109705986", Address = " chennai" },
                new Customer() { Id = 102, Name = "Sunil", Phone = "9981702479", Address = " chennai" },
                new Customer() { Id = 103, Name = "Gopal", Phone = "9981702479", Address = " chennai" }
                );
            modelBuilder.Entity<Pizza>().HasData(
               new Pizza() { Id = 101, PizzaName = "Margarita", Availability = "Available", Price = 99, QuantityInStock = 25 },
               new Pizza() { Id = 102, PizzaName = "Peppy Paneer", Availability = "Not Available", Price = 299, QuantityInStock = 0 },
               new Pizza() { Id = 103, PizzaName = "Farmhouse", Availability = "Available", Price = 299, QuantityInStock = 20 }
               );
        }
    }
}
