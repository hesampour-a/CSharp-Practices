namespace ZooManagement.ConsoleApp.Entities;

public class Zoo
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<Partition> Partitions { get; set; } = [];
}