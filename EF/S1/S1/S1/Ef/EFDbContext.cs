using Microsoft.EntityFrameworkCore;
using S1.Entities;

namespace S1.Ef;

internal class EFDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Guard> Guards { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=DESKTOP-5LA4REF;Database=EntityFrameworkS1;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Student>()
        // .HasMany(_ => _.StudentCourses)
        // .WithOne()
        // .HasForeignKey(_ => _.StudentId);

        // modelBuilder.Entity<Course>()
        // .HasMany(_ => _.StudentCourses)
        // .WithOne()
        // .HasForeignKey(_ => _.CourseId);
        // //.OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Course>()
        .HasOne(_ => _.Teacher)
        .WithMany()
        .HasForeignKey(_ => _.TeacherId);

        modelBuilder.Entity<Course>()
        .HasMany(_ => _.Exams)
        .WithOne()
        .HasForeignKey(_ => _.CourseId);


        modelBuilder.Entity<Guard>()
        .HasOne(_ => _.Exam)
        .WithMany()
        .HasForeignKey(_ => _.ExamId);

        modelBuilder.Entity<Guard>()
       .HasOne(_ => _.Teacher)
       .WithMany()
        .HasForeignKey(_ => _.TeacherId)
        .OnDelete(DeleteBehavior.NoAction);

    }
}
