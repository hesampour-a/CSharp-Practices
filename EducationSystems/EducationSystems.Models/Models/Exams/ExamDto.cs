namespace EducationSystems.Models.Models.Exams;

public class ExamDto
{
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = string.Empty;
    public double StudentsAverage { get; set; }
    public int StudentsCount { get; set; }
}
