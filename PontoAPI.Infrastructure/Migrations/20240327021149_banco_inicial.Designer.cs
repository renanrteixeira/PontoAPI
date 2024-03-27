﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoAPI.Infrastructure.Data;

#nullable disable

namespace PontoAPI.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240327021149_banco_inicial")]
    partial class bancoinicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PontoAPI.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar")
                        .HasColumnName("telephone");

                    b.HasKey("Id");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<DateOnly>("Admission")
                        .HasColumnType("date")
                        .HasColumnName("admission");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char")
                        .HasColumnName("gender");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.ToTable("employees", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Hour", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("id");

                    b.Property<TimeSpan>("Balance")
                        .HasColumnType("time")
                        .HasColumnName("balance");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Hour1")
                        .HasColumnType("time")
                        .HasColumnName("hour1");

                    b.Property<TimeSpan>("Hour2")
                        .HasColumnType("time")
                        .HasColumnName("hour2");

                    b.Property<TimeSpan>("Hour3")
                        .HasColumnType("time")
                        .HasColumnName("hour3");

                    b.Property<TimeSpan>("Hour4")
                        .HasColumnType("time")
                        .HasColumnName("hour4");

                    b.Property<TimeSpan>("Hour5")
                        .HasColumnType("time")
                        .HasColumnName("hour5");

                    b.Property<TimeSpan>("Hour6")
                        .HasColumnType("time")
                        .HasColumnName("hour6");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<int>("TypeDateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TypeDateId");

                    b.ToTable("hours", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.TypeDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time")
                        .HasColumnName("time");

                    b.Property<string>("Weekend")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char")
                        .HasColumnName("weekend");

                    b.HasKey("Id");

                    b.ToTable("typedates", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Admin")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char")
                        .HasColumnName("admin");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("char")
                        .HasColumnName("status");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Employee", b =>
                {
                    b.HasOne("PontoAPI.Core.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontoAPI.Core.Entities.Role", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Hour", b =>
                {
                    b.HasOne("PontoAPI.Core.Entities.Employee", "Employee")
                        .WithMany("Hours")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontoAPI.Core.Entities.TypeDate", "TypeDate")
                        .WithMany("Hours")
                        .HasForeignKey("TypeDateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("TypeDate");
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Employee", b =>
                {
                    b.Navigation("Hours");
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.Role", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PontoAPI.Core.Entities.TypeDate", b =>
                {
                    b.Navigation("Hours");
                });
#pragma warning restore 612, 618
        }
    }
}
