using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Rates;
using Library.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef;

public class EfDataContext : DbContext
{
    public EfDataContext(
        string connectionString)
        : this(
            new DbContextOptionsBuilder<EfDataContext>()
                .UseSqlServer(connectionString).Options)
    {
    }

    public EfDataContext(
        DbContextOptions<EfDataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Lend> Lends { get; set; }
    public DbSet<Rate> Rates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }
}