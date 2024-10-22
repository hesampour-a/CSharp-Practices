namespace ServiceCharge.Entities;

public class Floor
{
    public int Id { get; set; }
    public int UnitCount { get; set; }
    public required string Name { get; set; }
    public int BlockId { get; set; }

    public Block Block { get; set; } = default!;
}