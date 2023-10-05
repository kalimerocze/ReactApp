﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReactApp.Context;

#nullable disable

namespace ReactApp.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20230905072147_toEnglish")]
    partial class toEnglish
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ReactApp.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Popis")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Activity", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("ActivityHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("ReactApp.Models.Authorization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Popis")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Authorization", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("AuthorizationHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("ReactApp.Models.Employee", b =>
                {
                    b.Property<int>("IdZamestnance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdZamestnance"), 1L, 1);

                    b.Property<string>("Jmeno")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PracovniPozice")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prijmeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("TerminVyprseniKontraktu")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("IdZamestnance");

                    b.ToTable("Employee", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("EmployeeHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("ReactApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Heslo")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Jmeno")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prijmeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("UsersHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("ReactApp.Models.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nazev")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Popis")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("UserGroup", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("UserGroupHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });
#pragma warning restore 612, 618
        }
    }
}
