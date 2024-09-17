﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tickets.ConsoleApp.EfPersistence;

#nullable disable

namespace Tickets.ConsoleApp.Migrations
{
    [DbContext(typeof(EfDataContext))]
    [Migration("20240916131521_Edit_Trip_Ticket_Table")]
    partial class Edit_Trip_Ticket_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusType")
                        .HasColumnType("int");

                    b.Property<string>("Plaque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Buses", (string)null);
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuyType")
                        .HasColumnType("int");

                    b.Property<int>("TripId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DestinationCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PricePerTicket")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.ToTable("Trips", (string)null);
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Ticket", b =>
                {
                    b.HasOne("Tickets.ConsoleApp.Entities.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tickets.ConsoleApp.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Trip", b =>
                {
                    b.HasOne("Tickets.ConsoleApp.Entities.Bus", "Bus")
                        .WithMany("Trips")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Bus", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.Trip", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Tickets.ConsoleApp.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}