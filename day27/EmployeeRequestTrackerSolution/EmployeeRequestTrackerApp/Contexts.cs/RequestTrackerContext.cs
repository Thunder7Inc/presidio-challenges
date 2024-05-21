using EmployeeRequestTrackerApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EmployeeRequestTrackerApp.Contexts.cs
{
    public class RequestTrackerContext : DbContext
    {
        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "1234567890", Image = "",Role="Admin" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "1234567890", Image = "",Role="User" }
                );
        }
    }
}
