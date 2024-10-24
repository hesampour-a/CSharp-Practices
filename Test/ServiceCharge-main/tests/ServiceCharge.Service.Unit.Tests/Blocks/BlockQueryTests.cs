using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Services;
using ServiceCharge.Services.Blocks.Contracts.Dtos;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Service.Unit.Tests.Blocks;

public class BlockQueryTests : BusinessIntegrationTest
{
    private readonly BlockQuery _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public BlockQueryTests()
    {
        _sut = new EFBlockQuery(Context);
        _dateTimeServiceMock = new Mock<DateTimeService>();

        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));
    }

    [Fact]
    public void Get_get_one_block_properly()
    {
        var block1 = CreateBlock();
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 5,
        };
        block1.Floors.Add(floor1);
        var floor2 = new Floor()
        {
            Name = "Floor2",
            UnitCount = 7,
        };
        block1.Floors.Add(floor2);
        Save(block1);
        var block2 = CreateBlock("block2", 15);
        Save(block2);

        var result = _sut.Get(block1.Id);

        result.Should().NotBeNull();
        result.Name.Should().Be(block1.Name);
        result.FloorCount.Should().Be(block1.FloorCount);
        result.CreationDate.Should().Be(block1.CreationDate); //ERR
        result.Floors.Should().Contain(_ => _.Name == floor1.Name);
        result.Floors.Should().Contain(_ => _.Name == floor2.Name);

        // result.Should().BeEquivalentTo(new GetSingleBlockWithFloorsDto()
        // {
        //     Name = block1.Name,
        //     CreationDate = block1.CreationDate,
        //     FloorCount = block1.FloorCount,
        //     Floors =
        //     [
        //         new GetAllFloorsDto()
        //         {
        //             Name = floor1.Name,
        //             UnitCount = floor1.UnitCount,
        //             BlockId = block1.Id
        //         },
        //         new GetAllFloorsDto()
        //         {
        //             Name = floor2.Name,
        //             UnitCount = floor2.UnitCount,
        //             BlockId = block1.Id
        //         }
        //     ]
        // },_=>_.Excluding()); //how to exclud Floors.Id
    }

    [Fact]
    public void Get_get_all_blocks_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var block2 = CreateBlock("block2", 15);
        Save(block2);

        var result = _sut.GetAll();

        result.Should().ContainEquivalentOf(new GetAllBlocksDto()
        {
            Name = block1.Name,
            FloorCount = block1.FloorCount,
            CreationDate = block1.CreationDate,
            Id = block1.Id,
        });
        result.Should().ContainEquivalentOf(new GetAllBlocksDto()
        {
            Name = block2.Name,
            FloorCount = block2.FloorCount,
            CreationDate = block2.CreationDate,
            Id = block2.Id,
        });
    }

    [Fact]
    public void GetAllWithFloors_gets_all_blocks_with_floors_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = CreateFloor(block1.Id, "floor1");
        Save(floor1);

        var floor2 = CreateFloor(block1.Id, "floor2");
        Save(floor2);
        var block2 = CreateBlock("block2", 15);
        Save(block2);
        var result = _sut.GetAllWithFloors();

        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new GetAllBlocksWithFloorsDto()
        {
            Name = block1.Name,
            FloorCount = block1.FloorCount,
            CreationDate = block1.CreationDate,
            Id = block1.Id,
            Floors =
            [
                new GetAllFloorsDto()
                {
                    Name = floor1.Name,
                    UnitCount = floor1.UnitCount,
                    Id = floor1.Id,
                    BlockId = floor1.BlockId,
                },
                new GetAllFloorsDto()
                {
                    Name = floor2.Name,
                    UnitCount = floor2.UnitCount,
                    Id = floor2.Id,
                    BlockId = floor2.BlockId,
                }
            ]
        });

        result.Should().ContainEquivalentOf(new GetAllBlocksWithFloorsDto()
        {
            Name = block2.Name,
            FloorCount = block2.FloorCount,
            CreationDate = block2.CreationDate,
            Id = block2.Id,
            Floors = []
        });
    }

    private Block CreateBlock(string name = "block", int floorCount = 10)
    {
        return new Block()
        {
            Name = name,
            FloorCount = floorCount,
            CreationDate = _dateTimeServiceMock.Object.NowUtc,
        };
    }

    private Floor CreateFloor(int blockId, string name = "Floor",
        int unitCount = 2)
    {
        return new Floor()
        {
            Name = name,
            UnitCount = unitCount,
            BlockId = blockId,
        };
    }
}