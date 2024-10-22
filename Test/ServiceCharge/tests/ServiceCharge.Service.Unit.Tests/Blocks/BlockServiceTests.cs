using FluentAssertions;
using Moq;
using ServiceCharge.Entities;
using ServiceCharge.Services;

namespace ServiceCharge.Service.Unit.Tests.Blocks;

public class BlockServiceTests : BusinessIntegrationTest
{
    private readonly BlockService _sut;
    private readonly Mock<DateTimeService> _dateTimeServiceMock;

    public BlockServiceTests()
    {
        var repository = new EFBlockRepository(Context);
        _dateTimeServiceMock = new Mock<DateTimeService>();

        _dateTimeServiceMock.Setup(_ => _.NowUtc)
            .Returns(new DateTime(2020, 1, 1));
        
        _sut = new BlockAppService(repository,_dateTimeServiceMock.Object);
    }

    [Fact]
    public void Add_add_a_block_properly()
    {
        var dto = new AddBlockDto()
        {
            Name = "dummy",
            FloorCount = 10
        };
        
        _sut.Add(dto);

        var actual = ReadContext.Set<Block>().Single();
        actual.Should().BeEquivalentTo(new Block()
        {
            Name = dto.Name,
            FloorCount = dto.FloorCount,
            CreationDate = new DateTime(2020,1,1),
            Floors = []
        },_=>_.Excluding(a=>a.Id));
    }
}