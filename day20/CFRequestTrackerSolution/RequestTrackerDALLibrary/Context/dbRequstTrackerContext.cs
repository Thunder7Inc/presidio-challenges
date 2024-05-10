using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerDALLibrary.Models;
namespace RequestTrackerDALLibrary.Context
{
    internal class dbRequstTrackerContext : DbContext
    {
        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Request> Requests { get; set; }
        public DbSet<Models.Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=J9GCBX3\\KIKO;Initial Catalog=dbReqTracker;Integrated Security=True");
        }
    }
}
