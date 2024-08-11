using EducationSystems.Models.Interfaces;

namespace EducationSystems.Models.Models.Courses;

public class Course(string title) : HasIdClass
{
    public override int Id { get; set; }
    public string Title { get; set; } = title;
}
