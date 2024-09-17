using Microsoft.EntityFrameworkCore;

namespace Tickets.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
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