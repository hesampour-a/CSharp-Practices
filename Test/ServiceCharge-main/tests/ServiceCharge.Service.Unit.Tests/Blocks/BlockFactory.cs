using ServiceCharge.Entities;
using DateTime = System.DateTime;

namespace ServiceCharge.Service.Unit.Tests.Blocks;

public static class BlockFactory
{
    public static Block Create(
        string name = "dummy",
        int floorCount = 1,
        DateTime? creationDate = null)
    {
        creationDate ??= new DateTime(2021,1,1);
        return new Block
        {
            Name = name,
            CreationDate = creationDate.Value,
            FloorCount = floorCount
        };
    }
}

public class BlockBuilder
{
    private readonly Block _block;

    public BlockBuilder()
    {
        _block = new Block
        {
            Name = "name",
            CreationDate = new DateTime(2021,1,1),
            FloorCount = 1
        }; 
    }

    public BlockBuilder WithName(string name)
    {
        _block.Name = name;
        return this;
    }

    public BlockBuilder WithFloorCount(int floorCount)
    {
        _block.FloorCount = floorCount;
        return this;
    }

    public Block Build()
    {
        return _block;
    }
}

