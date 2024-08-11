namespace EducationSystems.Models.Models.ExamResults;

public class ExamResult(int examId,double grade)
{
    public int ExamId { get; init; } = examId;
    private double _grade;
    public double Grade
    {
        get => _grade;
        set
        {
            if (grade < 0 || grade > 20)
                throw new Exception("Grade must be between 0 and 20");
            _grade = grade;
        }
    }

}
