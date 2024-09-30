using EducationSystems.Models.Interfaces;

namespace EducationSystems.Models.Models.Exams;

public class Exam(int courseId, int teacherId, DateTime dateTime) : HasIdClass
{
    public override int Id { get; set; }
    public int CourseId { get; init; } = courseId;
    public int TeacherId { get; init; } = teacherId;
    private DateTime _date;
    public DateTime Date
    {
        get => _date;
        set
        {
            if (dateTime > DateTime.Now)
                throw new Exception("Date of exam must be in the past!");
            _date = dateTime;
        }
    }

}
