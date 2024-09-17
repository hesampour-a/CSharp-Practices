namespace ZooManagement.ConsoleApp.Entities;

public class Partition
{
    public int Id { get; set; }
    public int? AnimalId { get; set; }
    public Animal? Animal { get; set; }
    public int AnimalCount { get; set; }
    public int Area { get; set; }
    public string Description { get; set; } = String.Empty;
    public int ZooId { get; set; }
    public Zoo Zoo { get; set; }
    public Ticket Ticket { get; set; }
    
}