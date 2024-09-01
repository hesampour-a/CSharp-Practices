namespace S3.Models;

public class ExamGuard
{
    public int Id { get; set; }
    public virtual Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
    public virtual Exam Exam { get; set; }
    public int ExamId { get; set; }
}