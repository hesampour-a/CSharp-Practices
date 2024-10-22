using Microsoft.EntityFrameworkCore;
using Shop.Entities.Customers;
using Shop.Entities.OrderItems;
using Shop.Entities.Orders;
using Shop.Entities.Products;

namespace Shop.Persistence.Ef.Data;

public class EfDataContext(DbContextOptions<EfDataContext> options)
    : DbContext(options)
{
    
    public EfDataContext(
        string connectionString)
        : this(
            new DbContextOptionsBuilder<EfDataContext>()
                .UseSqlServer(connectionString).Options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }
}