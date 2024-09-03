namespace EFSession1.Models;

public class ExamGaurd
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
}