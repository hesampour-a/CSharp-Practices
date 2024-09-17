namespace ZooManagement.ConsoleApp.Dtos.Partitions;

public class ShowPartitonDto
{
    public int Id { get; set; }
    public int? AnimalId { get; set; }
    public int AnimalCount { get; set; }
    public int Area { get; set; }
    public string Description { get; set; } = String.Empty;
    public int ZooId { get; set; }
}