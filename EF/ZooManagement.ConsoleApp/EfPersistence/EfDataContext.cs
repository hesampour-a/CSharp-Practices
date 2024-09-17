using Microsoft.EntityFrameworkCore;
using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }
    public DbSet<Partition> Partitions { get; set; }
    public DbSet<Zoo> Zooes { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<SoldTicket> SoldTickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-5LA4REF;Database=ZooManagement2ConsoleApp;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}