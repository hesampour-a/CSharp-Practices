using Microsoft.EntityFrameworkCore;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances;

public class EfDataContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public DbSet<Customer> Customers { get; set; }

    // public DbSet<Models.Shop> Shops { get; set; }
    public DbSet<Personnel> Personnels { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

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
                "Server=DESKTOP-5LA4REF;Database=ConsoleShop;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        //.LogTo(Console.WriteLine,LogLevel.Information);
    }
}