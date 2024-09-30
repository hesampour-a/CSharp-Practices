using EducationSystems.Models.Interfaces;
using EducationSystems.Models.Models.ExamResults;

namespace EducationSystems.Models.Models.Students;

public class Student(string name,string natinalCode) : HasIdClass
{
    public override int Id { get; set; }
    public string Name { get; init; } = name;
    public string NationalCode { get; init; } = natinalCode;
    public List<ExamResult> ExamResults { get; set; }

}
