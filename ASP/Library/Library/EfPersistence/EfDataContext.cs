using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Library.EfPersistence;

public class EfDataContext(DbContextOptions<EfDataContext> options)
    : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Lend> Lends { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfDataContext)
            .Assembly);
    }
}