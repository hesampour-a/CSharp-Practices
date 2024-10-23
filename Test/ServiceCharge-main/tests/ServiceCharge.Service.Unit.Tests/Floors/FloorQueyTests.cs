using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.Floors;
using ServiceCharge.Services;
using ServiceCharge.Services.Floors.Contracts;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Service.Unit.Tests.Floors;

public class FloorQueyTests : BusinessIntegrationTest
{
    private readonly FloorQuery _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public FloorQueyTests()
    {
        _dateTimeServiceMock = new Mock<DateTimeService>();
        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));


        _sut = new EFFloorQuery(Context);
    }

    [Fact]
    public void GetAll_get_all_floors_properly()
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

        var result = _sut.GetAll();

        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new GetAllFloorsDto()
        {
            Name = floor1.Name,
            UnitCount = floor1.UnitCount,
            BlockId = floor1.BlockId,
            Id = floor1.Id,
        });
        result.Should().ContainEquivalentOf(new GetAllFloorsDto()
        {
            Name = floor2.Name,
            UnitCount = floor2.UnitCount,
            BlockId = floor2.BlockId,
            Id = floor2.Id,
        });
    }

    [Fact]
    public void GetAllWithUnits_get_all_floors_with_units_properly()
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
            FloorId = floor1.Id,
            IsActive = true
        };
        Save(unit1);
        var unit2 = new Entities.Unit()
        {
            Name = "Unit2",
            FloorId = floor1.Id,
            IsActive = false
        };
        Save(unit2);
        var floor2 = new Floor()
        {
            Name = "Floor2",
            UnitCount = 2,
            BlockId = block1.Id,
        };
        Save(floor2);
        var unit3 = new Entities.Unit()
        {
            Name = "Unit3",
            FloorId = floor2.Id,
            IsActive = true
        };
        Save(unit3);
        var unit4 = new Entities.Unit()
        {
            Name = "Unit4",
            FloorId = floor2.Id,
            IsActive = false
        };
        Save(unit4);

        var result = _sut.GetAllWithUnits();

        result.Should().HaveCount(2);

        result.Should().ContainEquivalentOf(new GetAllFloorsWithUnitsDto()
        {
            Name = floor1.Name,
            UnitCount = floor1.UnitCount,
            BlockId = floor1.BlockId,
            Id = floor1.Id,
            Units =
            [
                new GetAllUnitsDto()
                {
                    Name = unit1.Name,
                    FloorId = floor1.Id,
                    IsActive = unit1.IsActive,
                    Id = unit1.Id,
                },
                new GetAllUnitsDto()
                {
                    Name = unit2.Name,
                    FloorId = floor1.Id,
                    IsActive = unit2.IsActive,
                    Id = unit2.Id,
                }
            ]
        });

        result.Should().ContainEquivalentOf(new GetAllFloorsWithUnitsDto()
        {
            Name = floor2.Name,
            UnitCount = floor2.UnitCount,
            BlockId = floor2.BlockId,
            Id = floor2.Id,
            Units =
            [
                new GetAllUnitsDto()
                {
                    Name = unit3.Name,
                    FloorId = floor2.Id,
                    IsActive = unit3.IsActive,
                    Id = unit3.Id,
                },
                new GetAllUnitsDto()
                {
                    Name = unit4.Name,
                    FloorId = floor2.Id,
                    IsActive = unit4.IsActive,
                    Id = unit4.Id,
                }
            ]
        });
    }

    private Block CreateBlock(string name = "Block1", int floorCount = 5)
    {
        return new Block()
        {
            Name = name,
            FloorCount = floorCount,
            CreationDate = _dateTimeServiceMock.Object.NowUtc,
        };
    }
}