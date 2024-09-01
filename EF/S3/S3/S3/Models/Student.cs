namespace S3.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<StudentCourse> StudentCourses { get; set; }
}