namespace EFSession1.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public List<StudentCourse> StudentCourses{ get; set; }
    public List<Exam> Exams { get; set; }
    }