using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using S4.Migrations;
using S4.Models;

namespace S4.Data;

public class EfDataContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<School> Schools { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Country
        modelBuilder.Entity<Country>().ToTable("Countries");
        modelBuilder.Entity<Country>().HasKey(_ => _.Id);
        modelBuilder.Entity<Country>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<Country>().Property(_ => _.Title).IsRequired();

        //Province
        modelBuilder.Entity<Province>().ToTable("Provinces");
        modelBuilder.Entity<Province>().HasKey(_ => _.Id);
        modelBuilder.Entity<Province>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<Province>().Property(_ => _.Title).IsRequired();
        // modelBuilder.Entity<Province>()
        //     .HasOne(_ => _.Country)
        //     .WithMany(_ => _.Provinces)
        //     .HasForeignKey(_ => _.CountryId);

        //City
        modelBuilder.Entity<City>().ToTable("Cities");
        modelBuilder.Entity<City>().HasKey(_ => _.Id);
        modelBuilder.Entity<City>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<City>().Property(_ => _.Title).IsRequired();
        // modelBuilder.Entity<City>()
        //     .HasOne(_ => _.Province)
        //     .WithMany(_ => _.Cities)
        //     .HasForeignKey(_ => _.ProvinceId);

        //School
        modelBuilder.Entity<School>().ToTable("Schools");
        modelBuilder.Entity<School>().HasKey(_ => _.Id);
        modelBuilder.Entity<School>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<School>().Property(_ => _.Title).IsRequired();
        // modelBuilder.Entity<School>()
        //     .HasOne(_ => _.City)
        //     .WithMany(_ => _.Schools)
        //     .HasForeignKey(_ => _.CityId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(
                "Server=DESKTOP-5LA4REF;Database=S4;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        //.LogTo(Console.WriteLine,LogLevel.Information);
    }
}