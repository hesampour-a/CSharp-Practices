using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.Units;
using ServiceCharge.Services;
using ServiceCharge.Services.Units.Contracts;

namespace ServiceCharge.Service.Unit.Tests.Units;

public class UnitQueryTests : BusinessIntegrationTest
{
    private readonly UnitQuery _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public UnitQueryTests()
    {
        _dateTimeServiceMock = new Mock<DateTimeService>();
        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));


        _sut = new EFUnitQuery(Context);
    }

    [Fact]
    public void
        GetAllWithBlockNameAndFloorName_get_all_units_with_block_name_and_floor_name()
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

        var result = _sut.GetAllWithBlockNameAndFloorName();

        result.Should().HaveCount(4);

        result.Should().ContainEquivalentOf(
            new GetAllWithBlockNameAndFloorNameDto()
            {
                BlockName = block1.Name,
                Name = unit1.Name,
                FloorName = floor1.Name,
                IsActive = unit1.IsActive,
                FloorId = floor1.Id,
                Id = unit1.Id
            });

        result.Should().ContainEquivalentOf(
            new GetAllWithBlockNameAndFloorNameDto()
            {
                BlockName = block1.Name,
                Name = unit2.Name,
                FloorName = floor1.Name,
                IsActive = unit2.IsActive,
                FloorId = floor1.Id,
                Id = unit2.Id
            });
        result.Should().ContainEquivalentOf(
            new GetAllWithBlockNameAndFloorNameDto()
            {
                BlockName = block1.Name,
                Name = unit3.Name,
                FloorName = floor2.Name,
                IsActive = unit3.IsActive,
                FloorId = floor2.Id,
                Id = unit3.Id
            });
        result.Should().ContainEquivalentOf(
            new GetAllWithBlockNameAndFloorNameDto()
            {
                BlockName = block1.Name,
                Name = unit4.Name,
                FloorName = floor2.Name,
                IsActive = unit4.IsActive,
                FloorId = floor2.Id,
                Id = unit4.Id
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