namespace ServiceCharge.Entities;

public class Block
{
    public int Id { get; set; }
    public int FloorCount { get; set; }
    public required string Name { get; set; }
    public DateTime CreationDate { get; set; }

    public HashSet<Floor> Floors { get; set; } = [];
}