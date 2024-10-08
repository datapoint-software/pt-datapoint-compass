﻿// <auto-generated />
using System;
using Datapoint.Compass.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    [DbContext(typeof(CompassContext))]
    partial class CompassContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Country", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("CountryCode");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.County", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CountyCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("CountryCode", "DistrictCode", "CountyCode");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.District", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("CountryCode", "DistrictCode");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<Guid>("RowVersionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EmployeeRole", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("EmployeeId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EmployeeSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("Creation")
                        .HasColumnType("datetime");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset?>("Expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("RemoteAddress")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeSessions");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Enrollment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comments")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.Property<DateTimeOffset>("Creation")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("FacilityId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<Guid>("RowVersionId")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset?>("Start")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Number");

                    b.HasIndex("FacilityId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EnrollmentFacility", b =>
                {
                    b.Property<Guid>("EnrollmentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("FacilityId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId", "FacilityId");

                    b.HasIndex("FacilityId");

                    b.ToTable("EnrollmentFacilities");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Facility", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Description")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("RowVersionId")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Locality", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CountyCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("LocalityCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode");

                    b.ToTable("Localities");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Parameter", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("JsonValue")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.HasKey("Name");

                    b.ToTable("Parameters");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("RowVersionId")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.RolePermission", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.HasKey("RoleId", "Permission");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Sequence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("NextValue")
                        .HasColumnType("int");

                    b.Property<Guid>("RowVersionId")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Description")
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<Guid>("RowVersionId")
                        .IsConcurrencyToken()
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Street", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CountyCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("LocalityCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("StreetCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.HasKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode", "PostalCode", "StreetCode");

                    b.ToTable("Streets");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Zone", b =>
                {
                    b.Property<string>("CountryCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("DistrictCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("CountyCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("LocalityCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode", "PostalCode");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.County", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.District", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.District", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EmployeeRole", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EmployeeSession", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Enrollment", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EnrollmentFacility", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Enrollment", "Enrollment")
                        .WithMany()
                        .HasForeignKey("EnrollmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Facility", "Facility")
                        .WithMany()
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enrollment");

                    b.Navigation("Facility");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Locality", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.District", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.County", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.RolePermission", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Street", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.District", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.County", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Locality", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Zone", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode", "PostalCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Zone", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Country", null)
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.District", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.County", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Locality", null)
                        .WithMany()
                        .HasForeignKey("CountryCode", "DistrictCode", "CountyCode", "LocalityCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
