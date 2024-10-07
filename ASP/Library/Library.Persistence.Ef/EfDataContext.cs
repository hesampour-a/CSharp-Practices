using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Rates;
using Library.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Ef;

public class EfDataContext(DbContextOptions<EfDataContext> options)
    : DbContext(options)
{
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