using Library.Ef.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Ef.ConsoleApp.EfPersistence;

public class EfDataContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Server=DESKTOP-5LA4REF;Database=ConsoleLibrary;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}