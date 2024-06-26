﻿// <auto-generated />
using DoctorsAppointmentAPI.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorsAppointmentAPI.Migrations
{
    [DbContext(typeof(DoctorAppoinmentContext))]
    [Migration("20240514094810_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorsAppointmentAPI.models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DoctorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Experiance")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phonenumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorName = "Dr. Smith",
                            Experiance = 10,
                            Specialization = "Cardiology",
                            phonenumber = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            DoctorName = "Dr. Johnson",
                            Experiance = 8,
                            Specialization = "Pediatrics",
                            phonenumber = "987-654-3210"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
