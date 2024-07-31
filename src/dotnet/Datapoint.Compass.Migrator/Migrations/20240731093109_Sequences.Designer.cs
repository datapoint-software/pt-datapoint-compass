﻿// <auto-generated />
using System;
using Datapoint.Compass.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Datapoint.Compass.Migrator.Migrations
{
    [DbContext(typeof(CompassContext))]
    [Migration("20240731093109_Sequences")]
    partial class Sequences
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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
                        .IsConcurrencyToken()
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

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset?>("Expiration")
                        .HasColumnType("datetime");

                    b.Property<string>("RemoteAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("varchar(4096)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeeSessions");
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
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Code");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Facilities");
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
                    b.Property<string>("Name")
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<int>("LastNumber")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Sequences");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.EmployeeRole", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Employee", "Employee")
                        .WithMany("Roles")
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

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.RolePermission", b =>
                {
                    b.HasOne("Datapoint.Compass.EntityFrameworkCore.Entities.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Employee", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Datapoint.Compass.EntityFrameworkCore.Entities.Role", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
