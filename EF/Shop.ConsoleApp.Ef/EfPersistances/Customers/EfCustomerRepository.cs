using Shop.ConsoleApp.Ef.Dtos.Customers;
using Shop.ConsoleApp.Ef.EfPersistances.Orders;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.EfPersistances.Customers;

public class EfCustomerRepository(EfDataContext dbContext)
{
    private readonly EfOrderRepository orderRepository = new(dbContext);

    public void Create(Customer customer)
    {
        dbContext.Customers.Add(customer);
    }

    public List<ShowCustomerDto> GetAll()
    {
        //left join
        return (from user in dbContext.Users
                join customer in dbContext.Customers
                    on user.Id equals customer.UserId
                    into userCustomer
                from customer in userCustomer.DefaultIfEmpty()
                select new ShowCustomerDto
                {
                    Id = customer.Id == null ? 0 : customer.Id,
                    Name = user.Name
                }
            ).ToList();
    }

    public Customer? GetById(int id)
    {
        return dbContext.Customers.FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Customer customer)
    {
        var customerOrders = dbContext.Orders
            .Where(_ => _.CustomerId == customer.Id).ToList();
        orderRepository.DeleteRange(customerOrders);
        dbContext.Customers.Remove(customer);
    }
}