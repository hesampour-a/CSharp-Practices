using System.ComponentModel.DataAnnotations;
using System.Runtime;
using Microsoft.EntityFrameworkCore;

namespace EFSession1.Models;

public class Exam
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public List<ExamGaurd> ExamGaurds { get; set; }
}