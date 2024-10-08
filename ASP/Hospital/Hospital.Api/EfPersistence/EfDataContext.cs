﻿using System.Reflection;
using Hospital.Api.Entities.Doctors;
using Hospital.Api.Entities.Patients;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Api.EfPersistence;

public class EfDataContext(DbContextOptions<EfDataContext> options)
    : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }
}