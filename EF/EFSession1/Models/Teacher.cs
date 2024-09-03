namespace EFSession1.Models;

public class Teacher
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int YearsOfService { get; set; }
    public string PersonelId { get; set; }
    public List<Course> Courses { get; set; }
    public List<ExamGaurd> ExamGaurds { get; set; }

}
