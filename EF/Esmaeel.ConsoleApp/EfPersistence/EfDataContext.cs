using Esmaeel.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Esmaeel.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=DESKTOP-5LA4REF;Database=EsmaeelConsoleApp;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}