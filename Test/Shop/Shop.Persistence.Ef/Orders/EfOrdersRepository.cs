using Microsoft.EntityFrameworkCore;
using Shop.Entities.Orders;
using Shop.Persistence.Ef.Data;
using Shop.Services.OrderItems.Contracts.Dtos;
using Shop.Services.Orders.Contracts;
using Shop.Services.Orders.Contracts.Dtos;

namespace Shop.Persistence.Ef.Orders;

public class EfOrdersRepository(EfDataContext dbContext) : OrdersRepository
{
    public async Task CreateAsync(Order newOrder)
    {
        await dbContext.Orders.AddAsync(newOrder);
    }

    public async Task<IEnumerable<ShowAllOrdersDto>> GetAllAsync()
    {
        return await dbContext.Orders.Include(_ => _.OrderItems).Select(_ =>
            new ShowAllOrdersDto
            {
                Id = _.Id,
                CustomerId = _.CustomerId,
                OrderItems = _.OrderItems.Select(o => new ShowOrderItemDto
                {
                    Id = o.Id,
                    ProductId = o.ProductId,
                    Count = o.Count
                }).ToList()
            }).ToListAsync();
    }
}