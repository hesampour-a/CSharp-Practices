namespace S3.Models;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<Course> Courses { get; set; }
    public virtual List<ExamGuard> ExamGuards { get; set; }
}