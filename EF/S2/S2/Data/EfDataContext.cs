using Microsoft.EntityFrameworkCore;
using S2.Entities;

namespace S2.Data;

public class EfDataContext : DbContext
{
    public DbSet<CustomerPage> CustomerPages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Hashtag> Hashtags { get; set; }
    public DbSet<Follower> Followers { get; set; }
    public DbSet<FollowerIntrestedHashtag> FollowerIntrestedHashtags { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-5LA4REF;Database=S2;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.CustomerPage)
            .WithMany()
            .HasForeignKey(p=>p.CustomerPageId);
        
        modelBuilder.Entity<Hashtag>()
            .HasOne(p => p.Post)
            .WithMany()
            .HasForeignKey(h => h.PostId);

        modelBuilder.Entity<FollowerIntrestedHashtag>()
            .HasOne(_ => _.Follower)
            .WithMany()
            .HasForeignKey(_ => _.FollowerId);

        modelBuilder.Entity<FollowerIntrestedHashtag>()
            .HasOne(_ => _.Hashtag)
            .WithMany()
            .HasForeignKey(_ => _.HashtagId);

        modelBuilder.Entity<Recommendation>()
            .HasOne(_ => _.Follower)
            .WithMany()
            .HasForeignKey(_ => _.FollowerId);

        modelBuilder.Entity<Recommendation>()
            .HasOne(_ => _.Post)
            .WithMany()
            .HasForeignKey(_ => _.PostId);

    }
}