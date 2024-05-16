using System.Collections.Generic;
using System.Reflection.Emit;
using DoctorsAppointmentAPI.models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsAppointmentAPI.context
{
    public class DoctorAppoinmentContext : DbContext
    {
        public DoctorAppoinmentContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Doctor> Doctors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor()
                {
                    Id = 101,
                    DoctorName = "Neha Parmar",
                    phonenumber = "123456789",
                    Specialization = "Cardiology",
                    Experiance = 10 // Experience in years
                },
            new Doctor()
            {
                Id = 2,
                DoctorName = "Shailu",
                phonenumber = "9876543210",
                Specialization = "gayno",
                Experiance = 8 // Experience in years
            }
                );
        }
    }
}
