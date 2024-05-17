﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RankenSchedule.UI.Models.DataLayer;

#nullable disable

namespace RankenSchedule.UI.Migrations
{
    [DbContext(typeof(ClassScheduleContext))]
    [Migration("20240516091228_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int>("DayId")
                        .HasColumnType("int");

                    b.Property<string>("MilitaryTime")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int?>("Number")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ClassId");

                    b.HasIndex("DayId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            ClassId = 1,
                            DayId = 1,
                            MilitaryTime = "0800",
                            Number = 100,
                            TeacherId = 1,
                            Title = "Intro to c#"
                        },
                        new
                        {
                            ClassId = 2,
                            DayId = 2,
                            MilitaryTime = "0800",
                            Number = 101,
                            TeacherId = 1,
                            Title = "Intro to Web Dev"
                        },
                        new
                        {
                            ClassId = 3,
                            DayId = 3,
                            MilitaryTime = "0800",
                            Number = 102,
                            TeacherId = 1,
                            Title = "Intro to MERN"
                        },
                        new
                        {
                            ClassId = 4,
                            DayId = 4,
                            MilitaryTime = "0800",
                            Number = 103,
                            TeacherId = 1,
                            Title = "Intro to .NET MVC Core"
                        },
                        new
                        {
                            ClassId = 5,
                            DayId = 1,
                            MilitaryTime = "0800",
                            Number = 104,
                            TeacherId = 2,
                            Title = "Intro to Desktop Support"
                        },
                        new
                        {
                            ClassId = 6,
                            DayId = 1,
                            MilitaryTime = "0800",
                            Number = 105,
                            TeacherId = 3,
                            Title = "Intro to Hardware"
                        },
                        new
                        {
                            ClassId = 7,
                            DayId = 1,
                            MilitaryTime = "0800",
                            Number = 106,
                            TeacherId = 4,
                            Title = "Intro to IT Administrator"
                        },
                        new
                        {
                            ClassId = 8,
                            DayId = 1,
                            MilitaryTime = "0800",
                            Number = 107,
                            TeacherId = 5,
                            Title = "Intro to Networking"
                        });
                });

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DayId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("DayId");

                    b.ToTable("Days");

                    b.HasData(
                        new
                        {
                            DayId = 1,
                            Name = "Monday"
                        },
                        new
                        {
                            DayId = 2,
                            Name = "Tuesday"
                        },
                        new
                        {
                            DayId = 3,
                            Name = "Wednesday"
                        },
                        new
                        {
                            DayId = 4,
                            Name = "Thurdays"
                        },
                        new
                        {
                            DayId = 5,
                            Name = "Friday"
                        },
                        new
                        {
                            DayId = 6,
                            Name = "Saturday"
                        },
                        new
                        {
                            DayId = 7,
                            Name = "Sunday"
                        });
                });

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            FirstName = "Evan",
                            LastName = "Gudmestad"
                        },
                        new
                        {
                            TeacherId = 2,
                            FirstName = "Charles",
                            LastName = "Corrigan"
                        },
                        new
                        {
                            TeacherId = 3,
                            FirstName = "Ashley",
                            LastName = "Reddick"
                        },
                        new
                        {
                            TeacherId = 4,
                            FirstName = "Alan",
                            LastName = "Poettker"
                        },
                        new
                        {
                            TeacherId = 5,
                            FirstName = "Adesoji",
                            LastName = "Odetunde"
                        });
                });

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Class", b =>
                {
                    b.HasOne("RankenSchedule.UI.Models.DomainModels.Day", "Day")
                        .WithMany("Classes")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RankenSchedule.UI.Models.DomainModels.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Day");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Day", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("RankenSchedule.UI.Models.DomainModels.Teacher", b =>
                {
                    b.Navigation("Classes");
                });
#pragma warning restore 612, 618
        }
    }
}