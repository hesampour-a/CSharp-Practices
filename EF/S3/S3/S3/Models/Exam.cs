using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace S3.Models;

public class Exam
{
    public int Id { get; set; }
    //public DateTime Date { get; set; }
    public virtual Course Course { get; set; }
    public int CourseId { get; set; }
    public virtual List<ExamGuard> ExamGuards { get; set; }
}