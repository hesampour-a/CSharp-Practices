using EducationSystems.Models.Interfaces;

namespace EducationSystems.Models.Models.Teachers;

public class Teacher(string name,int personalId) : HasIdClass
{
    public override int Id { get; set; }
    public string Name { get; init; } = name;
    public int PersonalId { get; init; } = personalId;
}
