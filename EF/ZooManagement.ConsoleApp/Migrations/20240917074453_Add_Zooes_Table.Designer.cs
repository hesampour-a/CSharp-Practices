﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZooManagement.ConsoleApp.EfPersistence;

#nullable disable

namespace ZooManagement.ConsoleApp.Migrations
{
    [DbContext(typeof(EfDataContext))]
    [Migration("20240917074453_Add_Zooes_Table")]
    partial class Add_Zooes_Table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Animal", b =>
                {
                    b.Navigation("Partitions");
                });

            modelBuilder.Entity("ZooManagement.ConsoleApp.Entities.Zoo", b =>
                {
                    b.Navigation("Partitions");
                });
#pragma warning restore 612, 618
        }
    }
}