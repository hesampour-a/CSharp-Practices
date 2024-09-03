using EFSession1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQL.Extensions;

namespace EFSession1;

public class EFDataContext : DbContext 
{
    public DbSet<Teacher> Teacher { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<OnFieldExam> OnFieldExams { get; set; }
    public DbSet<User> User { get; set; }
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=.; Initial Catalog= EFSession3;Integrated Security=true;" +
            "Trust Server Certificate=true;").LogTo(Console.WriteLine,LogLevel.Information);
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        //Teacher
        modelBuilder.Entity<Teacher>().ToTable("UniversityTeachers");
        modelBuilder.Entity<Teacher>().HasKey(_=>_.Id);
        modelBuilder.Entity<Teacher>().Property(_ => _.Id).UseIdentityColumn();

        //modelBuilder.Entity<Teacher>().Property(_ => _.FirstName).IsRequired().HasMaxLength(500);
        // modelBuilder.Entity<Teacher>().Property(_ => _.LastName).IsRequired().HasMaxLength(500);
        // modelBuilder.Entity<Teacher>().Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(10);
        // modelBuilder.Entity<Teacher>().Property(_ => _.Email).IsRequired(false).HasMaxLength(500);
        // modelBuilder.Entity<Teacher>().Property(_ => _.NationalId).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Teacher>().Property(_ => _.YearsOfService).HasDefaultValue(0);
        modelBuilder.Entity<Teacher>().Property(_ => _.PersonelId).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Teacher>().HasMany(_ => _.ExamGaurds)
            .WithOne(_ => _.Teacher)
            .HasForeignKey(_ => _.TeacherId);
        modelBuilder.Entity<Teacher>()
            .HasOne(_ => _.User).WithOne()
            .HasForeignKey<Teacher>(_ =>
                _.UserId);
        //Student
        modelBuilder.Entity<Student>().ToTable("UniversityStudents");
        modelBuilder.Entity<Student>().HasKey(_ => _.Id);
        modelBuilder.Entity<Student>().Property(_ => _.Id).UseIdentityColumn();
        // modelBuilder.Entity<Student>().Property(_ => _.FirstName).IsRequired().HasMaxLength(500);
        // modelBuilder.Entity<Student>().Property(_ => _.LastName).IsRequired().HasMaxLength(500);
        // modelBuilder.Entity<Student>().Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(10);
        // modelBuilder.Entity<Student>().Property(_ => _.Email).IsRequired(false).HasMaxLength(500);
        // modelBuilder.Entity<Student>().Property(_ => _.NationalId).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Student>().Property(_ => _.TermNumber).HasDefaultValue(1);
        modelBuilder.Entity<Student>().Property(_ => _.StudentNumber).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<Student>()
            .HasMany(_ => _.StudentCourses)
            .WithOne(_ => _.Student)
            .HasForeignKey(_ => _.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Student>()
            .HasOne(_ => _.User).WithOne()
            .HasForeignKey<Student>(_ =>
                _.UserId);
        //Course
        modelBuilder.Entity<Course>().ToTable("Courses");        
        modelBuilder.Entity<Course>().HasKey(_ => _.Id);
        modelBuilder.Entity<Course>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<Course>().Property(_ => _.Title).IsRequired();
        modelBuilder.Entity<Course>().Property(_ => _.Value).HasDefaultValue(1);
        modelBuilder.Entity<Course>()
            .HasOne(_ => _.Teacher)
            .WithMany(_ => _.Courses)
            .HasForeignKey(_ => _.TeacherId).OnDelete(DeleteBehavior.NoAction);
        modelBuilder.Entity<Course>()
            .HasMany(_ => _.StudentCourses)
            .WithOne(_ => _.Course)
            .HasForeignKey(_ => _.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        //Exam
        modelBuilder.Entity<Exam>().HasKey(_ => _.Id);
        modelBuilder.Entity<Exam>().Property(_ => _.Id).UseIdentityColumn();
        modelBuilder.Entity<Exam>()
            .HasOne(_ => _.Course)
            .WithMany(_ => _.Exams)
            .HasForeignKey(_ => _.CourseId).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Exam>()
            .HasMany(_ => _.ExamGaurds)
            .WithOne(_ => _.Exam)
            .HasForeignKey(_ => _.ExamId);
     //on field exam

        modelBuilder.Entity<OnFieldExam>()
            .HasKey(_ => _.ExamId);
        modelBuilder.Entity<OnFieldExam>()
            .Property(_ => _.ExamTask)
            .IsRequired()
            .HasMaxLength(500);
        //User
        modelBuilder.Entity<User>().HasKey(_ => _.Id);
        modelBuilder.Entity<User>().Property(_=>_.Id).UseIdentityColumn();
        modelBuilder.Entity<User>().Property(_ => _.FirstName).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<User>().Property(_ => _.LastName).IsRequired().HasMaxLength(500);
        modelBuilder.Entity<User>().Property(_ => _.PhoneNumber).IsRequired().HasMaxLength(10);
        modelBuilder.Entity<User>().Property(_ => _.Email).IsRequired(false).HasMaxLength(500);
        modelBuilder.Entity<User>().Property(_ => _.NationalId).IsRequired().HasMaxLength(10);

base.OnModelCreating(modelBuilder);
    }
}