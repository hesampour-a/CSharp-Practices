using System.Text.Json.Serialization;

namespace S1.Entities;

public class Course
{
    public int Id { get; set; }
    public List<StudentCourse> StudentCourses { get; set; }
    public Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public List<Exam> Exams { get; set; }
}