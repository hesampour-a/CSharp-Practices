using Microsoft.EntityFrameworkCore;
using S4.Migrations;
using S4.Models;

namespace S4.Data;

public class EfDataContext : DbContext
{

    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Country
        modelBuilder.Entity<Country>().ToTable("Countries");
        modelBuilder.Entity<Country>().HasKey(_=>_.Id);
        modelBuilder.Entity<Country>().Property(_=>_.Id).UseIdentityColumn();
        modelBuilder.Entity<Country>().Property(_ => _.Title).IsRequired();
        
        //State
        modelBuilder.Entity<State>().ToTable("States");
        modelBuilder.Entity<State>().HasKey(_=>_.Id);
        modelBuilder.Entity<State>().Property(_=>_.Id).UseIdentityColumn();
        modelBuilder.Entity<State>().Property(_=>_.Title).IsRequired();
        modelBuilder.Entity<State>()
            .HasOne(_ => _.Country)
            .WithMany(_ => _.States)
            .HasForeignKey(_ => _.CountryId);

        //City
        modelBuilder.Entity<City>().ToTable("Cities");
        modelBuilder.Entity<City>().HasKey(_=>_.Id);
        modelBuilder.Entity<City>().Property(_=>_.Id).UseIdentityColumn();
        modelBuilder.Entity<City>().Property(_=>_.Title).IsRequired();
        modelBuilder.Entity<City>()
            .HasOne(_ => _.State)
            .WithMany(_ => _.Cities)
            .HasForeignKey(_ => _.StateId);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-5LA4REF;Database=S4;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    }
}