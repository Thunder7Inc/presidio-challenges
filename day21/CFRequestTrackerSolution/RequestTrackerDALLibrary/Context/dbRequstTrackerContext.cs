using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Context
{
    public class dbRequstTrackerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=J9GCBX3\KIKO;Initial Catalog=dbReqTracker;Integrated Security=True");
        }

        public DbSet<Models.Employee> Employees { get; set; }
        public DbSet<Models.Request> Requests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Request>()
                .HasOne(r => r.RaisedByEmployee)
                .WithMany(e => e.RequestsRaised)
                .HasForeignKey(r => r.RaisedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Models.Request>()
                .HasOne(r => r.ClosedByEmployee)
                .WithMany(e => e.RequestsClosed)
                .HasForeignKey(r => r.ClosedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
