using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Shop.Entities.Products;
using Shop.Persistence.Ef.Products;
using Shop.Persistence.Ef.UnitOfWorks;
using Shop.Services.Products;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;
using Shop.Services.Products.Exceptions;
using Shop.Services.Tests.Infrastructure.DataBaseConfig.Integration;
using Xunit;

namespace Shop.Services.Tests.Products;

public class ProductServiceTest : BusinessIntegrationTest
{
    private readonly ProductService _sut;

    public ProductServiceTest()
    {
        var unitOfWork = new EfUnitOfWork(Context);
        var productRepository = new EfProductsRepository(Context);
        _sut = new ProductAppService(unitOfWork, productRepository);
    }

    [Fact]
    public async Task Create_create_product_properly()
    {
        var dto = new CreateProductDto()
        {
            Price = 25000,
            Title = "Test Product",
            AvailableCount = 50
        };

        var result = await _sut.Create(dto);

        var actual = ReadContext.Set<Product>().Single();

        actual.Should().BeEquivalentTo(new Product()
        {
            Price = dto.Price,
            AvailableCount = dto.AvailableCount,
            Title = dto.Title,
            Id = result
        });
    }

    [Fact]
    public async Task Update_update_product_properly()
    {
        var product1 = new Product()
        {
            Price = 25000,
            Title = "Test Product",
            AvailableCount = 25,
        };
        Save(product1);
        var product2 = new Product()
        {
            Price = 250008,
            Title = "Test Product2",
            AvailableCount = 255,
        };
        Save(product2);
        var dto = new EditProductDto()
        {
            Price = 85000,
            AvailableCount = 100,
            Title = "Gholam"
        };
        await _sut.Update(product2.Id, dto);

        var actual = ReadContext.Set<Product>().ToList();

        actual.Should().ContainEquivalentOf(new Product()
        {
            Price = dto.Price,
            AvailableCount = dto.AvailableCount,
            Title = dto.Title,
            Id = product2.Id
        });

        actual.Should().ContainEquivalentOf(new Product()
        {
            Price = product1.Price,
            AvailableCount = product1.AvailableCount,
            Title = product1.Title,
            Id = product1.Id
        });

        //actual.Should().NotContain(_ => _.Title == product2.Title); //ERR
    }

    [Fact]
    public async Task Update_throw_exception_when_product_not_found()
    {
        int dummyId = -1;
        var dto = new EditProductDto();

        var actual = () => _sut.Update(dummyId, dto);

        await actual.Should().ThrowExactlyAsync<ProductNotFoundException>();
    }

    [Fact]
    public async Task Delete_delete_product_properly()
    {
        var product1 = new Product()
        {
            Price = 25000,
            Title = "Test Product",
            AvailableCount = 25,
        };
        Save(product1);
        var product2 = new Product()
        {
            Price = 250008,
            Title = "Test Product2",
            AvailableCount = 255,
        };
        Save(product2);
        await _sut.Remove(product1.Id);

        var actual = ReadContext.Set<Product>()
            .SingleOrDefault(_ => _.Id == product1.Id);

        actual.Should().BeNull();
    }

    [Fact]
    public async Task Delete_throw_exception_when_product_not_found()
    {
        int dummyId = -1;

        var actual = () => _sut.Remove(dummyId);

        await actual.Should().ThrowExactlyAsync<ProductNotFoundException>();
    }

    [Fact]
    public async Task GetAll_gets_all_products_properly()
    {
        var product1 = new Product()
        {
            Price = 25000,
            Title = "Test Product",
            AvailableCount = 25,
        };
        Save(product1);
        var product2 = new Product()
        {
            Price = 250008,
            Title = "Test Product2",
            AvailableCount = 255,
        };
        Save(product2);

        var result = await _sut.GetAll();

        result.Should().HaveCount(2);

        result.Should().ContainEquivalentOf(new ShowProductDto()
        {
            Id = product2.Id,
            AvailableCount = product2.AvailableCount,
            Title = product2.Title,
            Price = product2.Price
        });

        result.Should().ContainEquivalentOf(new ShowProductDto()
        {
            Id = product1.Id,
            AvailableCount = product1.AvailableCount,
            Title = product1.Title,
            Price = product1.Price
        });
    }
}