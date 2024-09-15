using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.Customers;
using Shop.ConsoleApp.Ef.EfPersistances.Orders;
using Shop.ConsoleApp.Ef.EfPersistances.Users;
using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class CustomerMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    private readonly EfCustomerRepository customerRepository = new(dbContext);

    private EfOrderRepository orderRepository = new(dbContext);

    //===============
    private readonly List<Action> testt1 = [];

    private readonly EfUserRepository userRepository = new(dbContext);
    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Create New Customer", CreateCustomer);
        MenuItems.Add("Show All Customers", ShowAllCustomers);
        MenuItems.Add("Edit Customer", EditCustomer);
        MenuItems.Add("Delete Customer", DeleteCustomer);
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui, "Back to Main Menu").Start();
    }

    private void CreateCustomer()
    {
        var newUser = new User
        {
            Name = ui.GetStringFromUser("Enter name :")
        };
        userRepository.Create(newUser);
        dbContext.SaveChanges();

        var newCustomer = new Customer
        {
            UserId = newUser.Id,
            Address = ui.GetStringFromUser("Enter Customer's Address :")
        };
        customerRepository.Create(newCustomer);
        dbContext.SaveChanges();
    }

    private void ShowAllCustomers()
    {
        var allCustomers = customerRepository.GetAll();

        allCustomers.ForEach(customer =>
        {
            ui.ShowMessage(
                $"Customer Id : {customer.Id} , Customer Name : {customer.Name} ");
        });
    }


    private void EditCustomer()
    {
        var customerId = ui.GetIntegerFromUser("Enter Customer id :");
        var customer =
            customerRepository.GetById(customerId)
            ?? throw new NotFoundException(nameof(Customer), customerId);
        var user = userRepository.GetById(customer.UserId);

        customer.Address =
            ui.GetStringFromUser("Enter Customer's new Address :");
        user.Name = ui.GetStringFromUser("Enter Customer's new name :");
        dbContext.SaveChanges();
    }

    private void DeleteCustomer()
    {
        var customerId = ui.GetIntegerFromUser("Enter Customer id :");
        var customer =
            customerRepository.GetById(customerId)
            ?? throw new NotFoundException(nameof(Customer), customerId);

        dbContext.SaveChanges();
    }

    private void method()
    {
        testt1.Add(DeleteCustomer);
    }
}