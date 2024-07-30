namespace Inheritance_Practice.BaseClasses;

public class User(string name, string address)
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
}