using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JetBrains.Annotations;
using Shop.Entities.Customers;
using Shop.Entities.Orders;
using Shop.Persistence.Ef.Customers;
using Shop.Persistence.Ef.UnitOfWorks;
using Shop.Services.Customers;
using Shop.Services.Customers.Contracts;
using Shop.Services.Customers.Contracts.Dtos;
using Shop.Services.Orders.Contracts.Dtos;
using Shop.Services.Tests.Infrastructure.DataBaseConfig.Integration;
using Xunit;

namespace Shop.Services.Tests.Customers;

[TestSubject(typeof(CustomersService))]
public class CustomersServiceTest : BusinessIntegrationTest
{
    private readonly CustomersService _sut;

    public CustomersServiceTest()
    {
        var unitOfWork = new EfUnitOfWork(Context);
        var customersRepository = new EfCustomersRepository(Context);

        _sut = new CustomersAppService(unitOfWork, customersRepository);
    }

    [Fact]
    public async void Create_should_create_customer()
    {
        //Arrange
        var dto = new CreateCustomerDto
        {
            Name = "John Doe",
            PhoneNumber = "0987654321",
        };

        //Act
        var result = await _sut.Create(dto);

        //Assert
        var actual = ReadContext.Customers.Single();

        actual.Id.Should().Be(result);
        actual.Name.Should().Be(dto.Name);
        actual.PhoneNumber.Should().Be(dto.PhoneNumber);
    }

    [Fact]
    public async void Get_should_return_customers()
    {
        //Arrange
        var customer1 = new Customer
        {
            Name = "John Doe",
            PhoneNumber = "0987654321",
        };
        Save(customer1);

        var customer2 = new Customer
        {
            Name = "mamad",
            PhoneNumber = "00000000",
        };
        Save(customer2);

        //Act
        var actual = await _sut.GetAll();
        var t = () => _sut.GetAll();


        //Assert
        actual.Should().NotBeEmpty();
        actual.Should().Contain(_ =>
            _.Name == customer1.Name && _.PhoneNumber == customer1.PhoneNumber);
        actual.Should().Contain(_ =>
            _.Name == customer2.Name && _.PhoneNumber == customer2.PhoneNumber);
    }

    [Fact]
    public async Task GetAllOrdersForUser()
    {
        var customer1 = new Customer()
        {
            Name = "John Doe1",
            PhoneNumber = "0987654321",
        };
        Save(customer1);
        var customer2 = new Customer()
        {
            Name = "John Doe2",
            PhoneNumber = "0987654322",
        };
        Save(customer2);
        var order1 = new Order()
        {
            CustomerId = customer1.Id,
        };
        Save(order1);
        var order2 = new Order()
        {
            CustomerId = customer2.Id,
        };
        Save(order2);
        var order3 = new Order()
        {
            CustomerId = customer2.Id,
        };
        Save(order3);

        var result = await _sut.GetAllOrdersForCustomer(customer2.Id);

        result.Should().HaveCount(2);
        result.Should().ContainEquivalentOf(new ShowOrderDto()
        {
            CustomerId = customer2.Id,
            Id = order2.Id
        });
        result.Should().ContainEquivalentOf(new ShowOrderDto()
        {
            CustomerId = customer2.Id,
            Id = order3.Id
        });
        result.Should().NotContain(_ => _.CustomerId == customer1.Id);
    }
}