using Inheritance_Practice.BaseClasses;

namespace Inheritance_Practice.DrivedClasses;

public class Emploee(string name, string address, double salary, int workExperience) : User(name, address)
{
    public double Salary { get; set; } = salary;
    public int WorkExperience { get; set; } = workExperience;

    public string Work()
        => $"{Name} is working";
}