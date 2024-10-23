using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Persistence.Ef.UnitOfWorks;
using ServiceCharge.Persistence.Ef.Units;
using ServiceCharge.Services;
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
        _sut = new UnitAppService(unitRepository, unitOfWork);
    }

    [Fact]
    public void Delete_delete_a_unit_properly()
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