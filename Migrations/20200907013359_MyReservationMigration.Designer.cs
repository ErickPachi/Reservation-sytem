﻿// <auto-generated />
using System;
using BeanSceneDipAssT2.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeanSceneDipAssT2.Migrations
{
    [DbContext(typeof(BeanSceneDBContext))]
    [Migration("20200907013359_MyReservationMigration")]
    partial class MyReservationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeanSceneDipAssT2.Areas.Identity.Data.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdditionalRequirements")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("SittingID")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("SittingID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Sitting", b =>
                {
                    b.Property<int>("SittingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SittingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Sitting_EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Sitting_StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SittingID");

                    b.ToTable("Sittings");

                    b.HasData(
                        new
                        {
                            SittingID = 1,
                            SittingName = "Breakfast",
                            Sitting_EndTime = new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Sitting_StartTime = new DateTime(1, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SittingID = 2,
                            SittingName = "Lunch",
                            Sitting_EndTime = new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified),
                            Sitting_StartTime = new DateTime(1, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            SittingID = 3,
                            SittingName = "Dinner",
                            Sitting_EndTime = new DateTime(1, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified),
                            Sitting_StartTime = new DateTime(1, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Table", b =>
                {
                    b.Property<int>("TableID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TableID");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableID = 1,
                            Area = "Main",
                            TableName = "M1"
                        },
                        new
                        {
                            TableID = 2,
                            Area = "Main",
                            TableName = "M2"
                        },
                        new
                        {
                            TableID = 3,
                            Area = "Main",
                            TableName = "M3"
                        },
                        new
                        {
                            TableID = 4,
                            Area = "Main",
                            TableName = "M4"
                        },
                        new
                        {
                            TableID = 5,
                            Area = "Main",
                            TableName = "M5"
                        },
                        new
                        {
                            TableID = 6,
                            Area = "Main",
                            TableName = "M6"
                        },
                        new
                        {
                            TableID = 7,
                            Area = "Main",
                            TableName = "M7"
                        },
                        new
                        {
                            TableID = 8,
                            Area = "Main",
                            TableName = "M8"
                        },
                        new
                        {
                            TableID = 9,
                            Area = "Main",
                            TableName = "M9"
                        },
                        new
                        {
                            TableID = 10,
                            Area = "Main",
                            TableName = "M10"
                        },
                        new
                        {
                            TableID = 11,
                            Area = "Balcony",
                            TableName = "B1"
                        },
                        new
                        {
                            TableID = 12,
                            Area = "Balcony",
                            TableName = "B2"
                        },
                        new
                        {
                            TableID = 13,
                            Area = "Balcony",
                            TableName = "B3"
                        },
                        new
                        {
                            TableID = 14,
                            Area = "Balcony",
                            TableName = "B4"
                        },
                        new
                        {
                            TableID = 15,
                            Area = "Balcony",
                            TableName = "B5"
                        },
                        new
                        {
                            TableID = 16,
                            Area = "Balcony",
                            TableName = "B6"
                        },
                        new
                        {
                            TableID = 17,
                            Area = "Balcony",
                            TableName = "B7"
                        },
                        new
                        {
                            TableID = 18,
                            Area = "Balcony",
                            TableName = "B8"
                        },
                        new
                        {
                            TableID = 19,
                            Area = "Balcony",
                            TableName = "B9"
                        },
                        new
                        {
                            TableID = 20,
                            Area = "Balcony",
                            TableName = "B10"
                        },
                        new
                        {
                            TableID = 21,
                            Area = "Outside",
                            TableName = "O1"
                        },
                        new
                        {
                            TableID = 22,
                            Area = "Outside",
                            TableName = "O2"
                        },
                        new
                        {
                            TableID = 23,
                            Area = "Outside",
                            TableName = "O3"
                        },
                        new
                        {
                            TableID = 24,
                            Area = "Outside",
                            TableName = "O4"
                        },
                        new
                        {
                            TableID = 25,
                            Area = "Outside",
                            TableName = "O5"
                        },
                        new
                        {
                            TableID = 26,
                            Area = "Outside",
                            TableName = "O6"
                        },
                        new
                        {
                            TableID = 27,
                            Area = "Outside",
                            TableName = "O7"
                        },
                        new
                        {
                            TableID = 28,
                            Area = "Outside",
                            TableName = "O8"
                        },
                        new
                        {
                            TableID = 29,
                            Area = "Outside",
                            TableName = "O9"
                        },
                        new
                        {
                            TableID = 30,
                            Area = "Outside",
                            TableName = "O10"
                        });
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Table_Reservation", b =>
                {
                    b.Property<int>("Table_ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("Table_ReservationID");

                    b.HasIndex("ReservationID");

                    b.HasIndex("TableID");

                    b.ToTable("Table_Reservations");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Reservation", b =>
                {
                    b.HasOne("BeanSceneDipAssT2.Domain.Customer", "Customer")
                        .WithMany("Reservation")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneDipAssT2.Domain.Sitting", "Sitting")
                        .WithMany("Reservation")
                        .HasForeignKey("SittingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeanSceneDipAssT2.Domain.Table_Reservation", b =>
                {
                    b.HasOne("BeanSceneDipAssT2.Domain.Reservation", "Reservation")
                        .WithMany("Table_Reservation")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneDipAssT2.Domain.Table", "Table")
                        .WithMany("Table_Reservation")
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BeanSceneDipAssT2.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BeanSceneDipAssT2.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeanSceneDipAssT2.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BeanSceneDipAssT2.Areas.Identity.Data.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}