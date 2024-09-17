using Microsoft.EntityFrameworkCore;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<Bus> Buses { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-5LA4REF;Database=TicketConsoleApp;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}