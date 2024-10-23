using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.Floors;
using ServiceCharge.Persistence.Ef.UnitOfWorks;
using ServiceCharge.Services;
using ServiceCharge.Services.Blocks.Exceptions;
using ServiceCharge.Services.Floors;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Contracts.Dtos;
using ServiceCharge.Services.Floors.Exceptions;

namespace ServiceCharge.Service.Unit.Tests.Floors;

public class FloorServiceTests : BusinessIntegrationTest
{
    private readonly FloorService _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public FloorServiceTests()
    {
        _dateTimeServiceMock = new Mock<DateTimeService>();
        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));

        var floorRepository = new EFFloorRepository(Context);
        var blockRepository = new EFBlockRepository(Context);
        var unitOfWork = new EfUnitOfWork(Context);
        _sut = new FloorAppService(floorRepository, blockRepository,
            unitOfWork);
    }

    [Fact]
    public void Add_add_a_floor_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var dto = new FloorAddDto
        {
            Name = "Name",
            UnitCount = 5
        };
        int result = _sut.Add(block1.Id, dto);

        var actual = ReadContext.Set<Floor>().Single();

        actual.Should().BeEquivalentTo(new Floor()
        {
            Name = dto.Name,
            UnitCount = dto.UnitCount,
            Id = result,
            BlockId = block1.Id,
        });
    }

    [Fact]
    public void Add_throws_exception_when_block_id_is_not_found()
    {
        int dummyId = -1;
        var dto = new FloorAddDto();


        var actual = () => _sut.Add(dummyId, dto);

        actual.Should().Throw<BlockNotFoundException>();
    }

    [Fact]
    public void Add_throws_exception_when_block_floors_count_is_max()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor1);
        var floor2 = new Floor()
        {
            Name = "Floor2",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor2);

        var dto = new FloorAddDto
        {
            Name = "Name",
            UnitCount = 5
        };

        var actual = () => _sut.Add(block1.Id, dto);

        actual.Should().ThrowExactly<BlockIsInMaxFloorsCountNumberException>();
    }

    [Fact]
    public void Update_update_a_floor_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 4,
            BlockId = block1.Id,
        };
        Save(floor1);
        var floor2 = new Floor()
        {
            Name = "Floor2",
            UnitCount = 4,
            BlockId = block1.Id,
        };
        Save(floor2);

        var dto = new FloorUpdateDto()
        {
            Name = "Edited",
            UnitCount = 12
        };

        _sut.Update(floor1.Id, dto);

        var actual = ReadContext.Set<Floor>()
            .FirstOrDefault(_ => _.Id == floor1.Id);

        actual.Should().BeEquivalentTo(new Floor()
        {
            Name = dto.Name,
            UnitCount = dto.UnitCount,
            Id = floor1.Id,
            BlockId = block1.Id
        });
    }

    [Fact]
    public void Update_throws_exception_when_floor_id_is_not_found()
    {
        int dummyId = -1;
        var dto = new FloorUpdateDto()
        {
            Name = "Name",
        };

        var actual = () => _sut.Update(dummyId, dto);

        actual.Should().ThrowExactly<FloorNotFoundException>();
    }

    [Fact]
    public void
        Update_throws_exception_when_floor_unit_count_is_more_than_new_unit_count()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor1);
        var unit1 = new Entities.Unit()
        {
            Name = "Unit1",
            IsActive = true,
            FloorId = floor1.Id,
        };
        Save(unit1);
        var unit2 = new Entities.Unit()
        {
            Name = "Unit2",
            IsActive = true,
            FloorId = floor1.Id,
        };
        Save(unit2);

        var dto = new FloorUpdateDto()
        {
            Name = "Name",
            UnitCount = 1
        };

        var actual = () => _sut.Update(floor1.Id, dto);

        actual.Should().ThrowExactly<FloorAlredyHasMoreUnitsException>();
    }

    [Fact]
    public void Delete_delete_a_floor_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor1);
        var floor2 = new Floor()
        {
            Name = "Floor2",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor2);

        _sut.Delete(floor2.Id);

        var actual = ReadContext.Set<Floor>().Single();

        actual.Should().BeEquivalentTo(new Floor()
        {
            Name = floor1.Name,
            UnitCount = floor1.UnitCount,
            BlockId = block1.Id,
            Id = floor1.Id,
        });
    }

    [Fact]
    public void Delete_throws_exception_if_floor_not_found()
    {
        var dummyId = -1;

        var actual = () => _sut.Delete(dummyId);

        actual.Should().ThrowExactly<FloorNotFoundException>();
    }

    [Fact]
    public void Delete_throws_exception_if_floor_has_units()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = new Floor()
        {
            Name = "Floor1",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor1);
        var unit1 = new Entities.Unit()
        {
            Name = "Unit1",
            IsActive = true,
            FloorId = floor1.Id,
        };
        Save(unit1);


        var actual = () => _sut.Delete(floor1.Id);

        actual.Should().ThrowExactly<FloorHasUnitsException>();
    }

    private Block CreateBlock(string name = "Block1", int floorCount = 2)
    {
        return new Block()
        {
            Name = name,
            FloorCount = floorCount,
            CreationDate = _dateTimeServiceMock.Object.NowUtc,
        };
    }
}