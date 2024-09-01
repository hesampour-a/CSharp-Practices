using System.Text.Json.Serialization;

namespace S1.Entities;

public class Guard
{
    public int Id { get; set; }
    public Exam Exam { get; set; }
    public int ExamId { get; set; }
    public Teacher Teacher { get; set; }
    public int TeacherId { get; set; }
}