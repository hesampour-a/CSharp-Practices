using Microsoft.EntityFrameworkCore;
using S3.Models;

namespace S3.Data;

public class EfDataContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamGuard> ExamGuards { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Course>()
            .HasOne(_ => _.Teacher)
            .WithMany(_ => _.Courses)
            .HasForeignKey(_ => _.TeacherId);
        
        modelBuilder.Entity<StudentCourse>()
            .HasOne(_ => _.Course)
            .WithMany(_ => _.StudentCourses)
            .HasForeignKey( _ => _.CourseId);
        
        modelBuilder.Entity<StudentCourse>()
            .HasOne(_ => _.Student)
            .WithMany(_=>_.StudentCourses)
            .HasForeignKey( _ => _.StudentId);
        
        modelBuilder.Entity<Exam>()
            .HasOne(_=>_.Course)
            .WithMany(_=>_.Exams)
            .HasForeignKey( _ => _.CourseId);
        
        modelBuilder.Entity<ExamGuard>()
            .HasOne(_ => _.Exam)
            .WithMany(_ => _.ExamGuards)
            .HasForeignKey( _ => _.ExamId);
        
        modelBuilder.Entity<ExamGuard>()
            .HasOne(_ => _.Teacher)
            .WithMany(_ => _.ExamGuards)
            .HasForeignKey( _ => _.TeacherId)
            .OnDelete(DeleteBehavior.NoAction);
            
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-5LA4REF;Database=S3;Trusted_Connection=true;MultipleActiveResultSets=true;TrustServerCertificate=True;");
    }
}