﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooManagement.ConsoleApp.EfPersistence;

#nullable disable

namespace ZooManagement.ConsoleApp.Migrations
{
    [DbContext(typeof(EfDataContext))]
    partial class EfDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals", (string)null);
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Partition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalCount")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ZooId");

                    b.ToTable("Partitions", (string)null);
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.SoldTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("SoldTickets", (string)null);
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PartitionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PartitionId")
                        .IsUnique();

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zooes", (string)null);
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Partition", b =>
                {
                    b.HasOne("ZooManagement.ConsoleApp.Entities.Animal", "Animal")
                        .WithMany("Partitions")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ZooManagement.ConsoleApp.Entities.Zoo", "Zoo")
                        .WithMany("Partitions")
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.SoldTicket", b =>
                {
                    b.HasOne("ZooManagement.ConsoleApp.Entities.Ticket", "Ticket")
                        .WithMany("SoldTickets")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Ticket", b =>
                {
                    b.HasOne("ZooManagement.ConsoleApp.Entities.Partition", "Partition")
                        .WithOne("Ticket")
                        .HasForeignKey("ZooManagement.ConsoleApp.Entities.Ticket", "PartitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partition");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Animal", b =>
                {
                    b.Navigation("Partitions");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Partition", b =>
                {
                    b.Navigation("Ticket")
                        .IsRequired();
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Ticket", b =>
                {
                    b.Navigation("SoldTickets");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Zoo", b =>
                {
                    b.Navigation("Partitions");
                });
#pragma warning restore 612, 618
        }
    }
}
