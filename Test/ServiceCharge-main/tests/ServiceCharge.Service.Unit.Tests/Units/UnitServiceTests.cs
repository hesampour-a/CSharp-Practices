using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.Floors;
using ServiceCharge.Persistence.Ef.UnitOfWorks;
using ServiceCharge.Persistence.Ef.Units;
using ServiceCharge.Services;
using ServiceCharge.Services.Floors.Exceptions;
using ServiceCharge.Services.Units;
using ServiceCharge.Services.Units.Contracts;
using ServiceCharge.Services.Units.Exceptions;

namespace ServiceCharge.Service.Unit.Tests.Units;

public class UnitServiceTests : BusinessIntegrationTest
{
    private readonly UnitService _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public UnitServiceTests()
    {
        _dateTimeServiceMock = new Mock<DateTimeService>();
        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));

        var unitRepository = new EFUnitRepository(Context);
        var unitOfWork = new EfUnitOfWork(Context);
        var floorRepository = new EFFloorRepository(Context);
        _sut = new UnitAppService(unitRepository, unitOfWork,floorRepository);
    }

    [Fact]
    public void Delete_delete_a_unit_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = CreateFloor(block1.Id, "Floor1");
        Save(floor1);
        var unit1 = CreateUnit(floor1.Id, "Unit1");
        Save(unit1);
        var unit2 = CreateUnit(floor1.Id, "Unit2");
        Save(unit2);

        _sut.Delete(unit1.Id);

        var actual = ReadContext.Set<Entities.Unit>().Single();

        actual.Should().BeEquivalentTo(new Entities.Unit()
        {
            Name = unit2.Name,
            IsActive = unit2.IsActive,
            FloorId = unit2.FloorId,
            Id = unit2.Id,
        });
    }

    [Fact]
    public void Delete_throws_exception_if_unit_does_not_exist()
    {
        var dummyId = -1;

        var actual = () => _sut.Delete(dummyId);

        actual.Should().ThrowExactly<UnitNotFoundException>();
    }

    [Fact]
    public void Add_add_a_unit_properly()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = CreateFloor(block1.Id, "Floor1");
        Save(floor1);

        var dto = new CreateUnitDto()
        {
            Name = "unit1",
            IsActive = true,
        };

        var result = _sut.Add(floor1.Id, dto);

        var actual = ReadContext.Set<Entities.Unit>().Single();

        actual.Should().BeEquivalentTo(new Entities.Unit
        {
            Name = dto.Name,
            IsActive = dto.IsActive,
            FloorId = floor1.Id,
            Id = result
        });
    }

    [Fact]
    public void Add_throws_exception_if_floor_does_not_exist()
    {
        var dummyId = -1;
        var dto = new CreateUnitDto()
        {
            Name = "unit1",
        };

        var actual = () => _sut.Add(dummyId, dto);

        actual.Should().ThrowExactly<FloorNotFoundException>();
    }

    [Fact]
    public void Add_throws_exception_when_floor_has_max_number_of_units()
    {
        var block1 = CreateBlock();
        Save(block1);
        var floor1 = CreateFloor(block1.Id, "Floor1",1);
        Save(floor1);
        var unit1 = CreateUnit(floor1.Id, "Unit1");
        Save(unit1);

        var dto = new CreateUnitDto()
        {
            Name = "unit2",
            IsActive = true,
        };
        
        var actual = () => _sut.Add(floor1.Id, dto);
        
        actual.Should().ThrowExactly<FloorAlredyHasMoreUnitsException>();
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

    private Entities.Unit CreateUnit(int floorId, string unitName = "unit",
        bool isActive = true)
    {
        return new Entities.Unit()
        {
            Name = unitName,
            IsActive = isActive,
            FloorId = floorId,
        };
    }
}