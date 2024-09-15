using BuildingManagement.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuildingManagement.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<Block> Blocks { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Cost> Costs { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Server=DESKTOP-5LA4REF;Database=BuildingConsoleApp;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}