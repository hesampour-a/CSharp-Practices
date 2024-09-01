namespace S1.Entities;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<StudentCourse> StudentCourses { get; set; }

}