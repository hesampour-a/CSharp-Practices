namespace ZooManagement.ConsoleApp.Entities;

public class Animal
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<Partition> Partitions { get; set; } = [];
}