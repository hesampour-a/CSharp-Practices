namespace S3.Models;

public class Course
{
    public int Id { get; set; }
    public virtual Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public virtual List<StudentCourse> StudentCourses { get; set; }
    public virtual List<Exam> Exams { get; set; }
    
}