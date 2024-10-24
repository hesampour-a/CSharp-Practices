using BuilderFactory;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.UnitOfWorks;
using ServiceCharge.Services;
using ServiceCharge.Services.Blocks.Contracts.Dtos;
using ServiceCharge.Services.Blocks.Exceptions;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Service.Unit.Tests.Blocks;

public class BlockServiceTests : BusinessIntegrationTest
{
    private readonly BlockService _sut; 
    private readonly Mock<DateTimeService> _dateTimeServiceMock;
    private readonly DateTime _fakeDateTime;

    public BlockServiceTests()
    {
        var repository = new EFBlockRepository(Context);
        
        _dateTimeServiceMock = new Mock<DateTimeService>();

        _fakeDateTime = new DateTime(2021, 1, 1);
        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(_fakeDateTime);

        var unitOfWork = new EfUnitOfWork(Context);

        _sut = new BlockAppService(
            repository,
            unitOfWork,
            _dateTimeServiceMock.Object);
    }

    [Fact]
    public void Add_add_a_block_properly()
    {
        var dto = new AddBlockDto()
        {
            Name = "dummy",
            FloorCount = 10
        };

        var result = _sut.Add(dto);
        
        var actual = ReadContext.Set<Block>().Single();
        actual.Should().BeEquivalentTo(new Block()
        {
            Name = dto.Name,
            FloorCount = dto.FloorCount,
            CreationDate = _fakeDateTime,
            Floors = []
        });
        result.Should().Be(actual.Id);
    }

    [Fact]
    public void Add_throw_exception_when_block_name_duplicated()
    {
        var block = BlockFactory.Create("name");
        Save(block);
        var dto = new AddBlockDto()
        {
            Name = "name"
        };

        var actual = () => _sut.Add(dto);

        actual.Should().ThrowExactly<BlockNameDuplicateException>();
    }

    [Fact]
    public void AddWithFloor_()
    {
        var dto = new AddBlockWithFloorDto()
        {
            Name = "block1",
            Floors =
            [
                new FloorAddDto
                {
                    Name = "floor1",
                    UnitCount = 2
                }
            ]
        };

        _sut.AddWithFloor(dto);

        var actual = ReadContext.Set<Block>()
            .Include(_ => _.Floors)
            .Single();
        actual.Name.Should().Be("block1");
        actual.FloorCount.Should().Be(1);
        actual.Floors.Should().HaveCount(1);
        actual.Floors.Should()
            .Contain(_ => _.Name == "floor1" && _.UnitCount == 2);
    }

    [Fact]
    public void Update_update_block_properly()
    {
        var block = BlockFactory.Create();
        Save(block);
        var block2 = BlockFactory.Create("block2",5);
        Save(block2);
        var dto = new UpdateBlockDto()
        {
            Name = "Edited",
            FloorCount = 9
        };
        
        _sut.Update(block.Id, dto);

        var actual = ReadContext.Set<Block>()
            .ToList();
        actual.Should().ContainEquivalentOf(new Block()
        {
            Name = dto.Name,
            FloorCount = dto.FloorCount,
            CreationDate = _dateTimeServiceMock.Object.NowUtc,
            Id = block.Id
        });
        actual.Should().ContainEquivalentOf(new Block()
        {
            Name = block2.Name,
            FloorCount = block2.FloorCount,
            CreationDate = _dateTimeServiceMock.Object.NowUtc,
            Id = block2.Id
        });
    }

    [Fact]
    public void Update_throw_exception_when_block_does_not_exist()
    {
        var dummyId = -1;
        var dto = new UpdateBlockDto()
        {
            Name = "block",
            FloorCount = 78
        };

        var actual = () => _sut.Update(dummyId, dto);
        actual.Should().ThrowExactly<BlockNotFoundException>();
    }

    [Fact]
    public void Update_throw_exception_when_block_name_duplicated()
    {
        var block1 = new BlockBuilder()
            .WithName("ali")
            .WithFloorCount(12)
            .Build();
        Save(block1);
        var floor = Instance.From<Block>()
            .SetProperty(_ => _.Name = "adf")
            .SetProperty(_=>_.Type = 1)
            .Build();

        var block2 = BlockFactory.Create("block2");
        Save(block2);

        var dto = new UpdateBlockDto()
        {
            Name = "block2",
            FloorCount = 60
        };
        var actual = () => _sut.Update(block1.Id, dto);
        actual.Should().ThrowExactly<BlockNameDuplicateException>();
    }

    [Fact]
    public void
        Update_throw_exception_when_new_floorCount_is_less_than_existing_floors_count()
    {
        var block1 = BlockFactory.Create(name:"1",floorCount:1);
        block1.Floors.Add(new Floor()
        {
            Name = "floor1",
            UnitCount = 4,
        });
        block1.Floors.Add(new Floor()
        {
            Name = "floor2",
            UnitCount = 4,
        });
        Save(block1);

        var dto = new UpdateBlockDto()
        {
            Name = "block1",
            FloorCount = 1
        };

        var actual = () => _sut.Update(block1.Id, dto);
        actual.Should().ThrowExactly<BlockAlredyHasMoreFloorsExceptions>();
    }
}