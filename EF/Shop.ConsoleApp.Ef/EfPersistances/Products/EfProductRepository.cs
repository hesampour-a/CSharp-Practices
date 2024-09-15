using Shop.ConsoleApp.Ef.Dtos.Products;
using Shop.ConsoleApp.Ef.EfPersistances.OrderItems;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Products;

public class EfProductRepository(EfDataContext dbContext)
{
    private readonly EfOrderItemRepository orderItemRepository = new(dbContext);

    public Product? GetById(int productId)
    {
        return dbContext.Products.FirstOrDefault(_ => _.Id == productId);
    }

    public List<ShowProductReportDto> GetProductsReport()
    {
        var allProducts = (
            from product in dbContext.Products
            join orderItem in dbContext.OrderItems
                on product.Id equals orderItem.ProductId
            select new
            {
                product.Id,
                product.Title,
                SoldQuantity = orderItem.ProductCount
            }).ToList();

        return allProducts.GroupBy(_ => _.Id).Select(_ =>
            new ShowProductReportDto
            {
                Id = _.Key,
                Title = _.First().Title,
                SoldQuantity = _.Sum(_ => _.SoldQuantity),

                Count = _.Count()
            }).OrderByDescending(g => g.Count).ToList();
    }

    public void Add(Product newProduct)
    {
        dbContext.Products.Add(newProduct);
    }

    public List<ShowProductDto> GetProducts()
    {
        return dbContext.Products.Select(_ => new ShowProductDto
        {
            Id = _.Id,
            Price = _.Price,
            Title = _.Title
        }).ToList();
    }

    public void Delete(Product product)
    {
        var orderItems = dbContext.OrderItems
            .Where(_ => _.ProductId == product.Id).ToList();
        orderItemRepository.DeleteRange(orderItems);
        dbContext.Products.Remove(product);
    }
}