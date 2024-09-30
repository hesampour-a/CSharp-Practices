using EfStoreSession6_Practice.EFPersistance.Users;
using EfStoreSession6_Practice.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfStoreSession6_Practice.EFPersistance;

public class EFDataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
                "Data Source=.; Initial Catalog= EFSession6;Integrated Security=true;" +
                "Trust Server Certificate=true;")
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(
                typeof(UserEntityMap).Assembly);
    }
}