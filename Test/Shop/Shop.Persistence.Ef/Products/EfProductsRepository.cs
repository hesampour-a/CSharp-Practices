using Microsoft.EntityFrameworkCore;
using Shop.Entities.Products;
using Shop.Persistence.Ef.Data;
using Shop.Services.Products.Contracts;
using Shop.Services.Products.Contracts.Dtos;

namespace Shop.Persistence.Ef.Products;

public class EfProductsRepository(EfDataContext dbContext) : ProductsRepository
{
    public async Task CreateAsync(Product newProduct)
    {
        await dbContext.Products.AddAsync(newProduct);
    }

    public async Task<IEnumerable<ShowProductDto>> GetAllAsync(string? search)
    {
        var baseQuery = dbContext.Products.AsQueryable();

        if (search is not null)
            baseQuery = baseQuery.Where(x => x.Title.Contains(search));

        return await baseQuery.Select(_ => new ShowProductDto
        {
            Id = _.Id,
            Price = _.Price,
            AvailableCount = _.AvailableCount,
            Title = _.Title
        }).ToListAsync();
    }

    public async Task<Product> FindByIdAsync(int id)
    {
        return await dbContext.Products.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public void Remove(Product product)
    {
        dbContext.Products.Remove(product);
    }

    public async Task<decimal> GetPriceById(int orderItemProductId)
    {
        return await dbContext.Products.Where(_ => _.Id == orderItemProductId)
            .Select(_ => _.Price).SingleOrDefaultAsync();
    }
}