namespace Inheritance_Practice.DrivedClasses;

public class Programmer(
    string name,
    string address,
    double salary,
    int workExperience,
    string programmingLanguage)
    : Emploee(name, address, salary, workExperience)
{
    public string ProgrammingLanguage { get; set; } = programmingLanguage;
    public string Code()
        => $"{Name} is coding with {ProgrammingLanguage}";
}