namespace EFSession1.Models;

public class Student
{
    public int Id { get; set; }
    public int TermNumber { get; set; }
    public string StudentNumber { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public List<StudentCourse> StudentCourses { get; set; }
}