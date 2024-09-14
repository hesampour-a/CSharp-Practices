
using EfStoreSession6_Practice.EFPersistance;
using EfStoreSession6_Practice.EFPersistance.Employees;
using EfStoreSession6_Practice.EFPersistance.Stores;
using EfStoreSession6_Practice.EFPersistance.Users;
using EfStoreSession6_Practice.Entities;

var context = new EFDataContext();
var userRepository = new EFUserRepository(context);
var employeeRepository = new EFEmployeeRepository(context);
var storeRepository = new EFStoreRepository(context);
while (true)
{
    try
    {
        Run();

    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
}

void Run()
{
    Console.WriteLine("1- Add Employee\n" +
                      "2- View Employees\n" +
                      "3- Add Store\n" +
                      "4- View Stores\n" +
                      "5- Add employee to store\n" +
                      "6- Edit employee\n" +
                      "7- Delete Employee\n");
    Console.WriteLine("Please choose an option:");
    var option = Console.ReadLine();
    switch (option)
    {
        case "1":
        {
            context.Database.BeginTransaction();
            try
            {
                var user = CreateUser();
                context.SaveChanges();
                CreateEmployee(user.Id);
                context.SaveChanges();
                context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
            }
            // var userId = CreateUser();
            // var employeeId = CreateEmployee(userId);
            // Console.WriteLine(employeeId);
        }
            break;
        case "2":
        {
            ViewAllEmployees();
        }
            break;
        case "3":
        {
            AddStore();
        }
            break;
        case "4":
        {
            ViewStores();
        }
            break;
        case "5":
        {
            AddEmployeeToStore();
        }
            break;
        case "6":
        {
            EditEmployee();
        }
            break;
        case "7":
        {
            DeleteEmployee();
        }
            break;
        default:
            Console.WriteLine("Invalid Input!");
            break;
    }
}
#region services
User CreateUser()
{
    Console.WriteLine("Enter first name:");
    var firstName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(firstName))
    {
        throw new Exception();
    }
    if (firstName.Length>100)
    {
        throw new Exception();
    }
    Console.WriteLine("Enter last name:");
    var lastName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(lastName))
    {
        throw new Exception();
    }
    if (lastName.Length>100)
    {
        throw new Exception();
    }
    Console.WriteLine("Enter Phone number:");
    var phoneNumber = Console.ReadLine();
    var user = new User
    {
        FirstName = firstName,
        LastName = lastName,
        PhoneNumber = phoneNumber
    };
    userRepository.Add(user);
    return user;
}

void CreateEmployee(int userId)
{
    Console.WriteLine("Enter personel number:");
    var personelNumber = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(personelNumber))
    {
        throw new Exception();
    }
    var employee = new Employee()
    {
        UserId = userId,
        PersonnelNumber = personelNumber
    };
    employeeRepository.Add(employee);
}

void ViewAllEmployees()
{
    var employees =
        employeeRepository.GetAll();

    foreach (var employee  in employees)
    {
        Console.WriteLine($"{employee.EmployeeId} - {employee.FirstName} {employee.LastName} " +
                          $"- Phone number: {employee.PhoneNumber} " +
                          $"- Personnel Code: {employee.PersonnelNumber} " +
                          $"- Store name: {employee.StoreName}");
    }
}

void AddStore()
{
    Console.WriteLine("Enter store name");
    var storeName = Console.ReadLine();
    var store = new Store()
    {
        Name = storeName
    };
    storeRepository.Add(store);
    context.SaveChanges();
    Console.WriteLine(store.Id);
}

void ViewStores()
{
    var stores = storeRepository.GetAll();
    foreach (var store in stores)
    {
        Console.WriteLine($"{store.Id} - {store.Name}");
    }
}

void AddEmployeeToStore()
{
    ViewAllEmployees();
    Console.WriteLine("select employee id");
    int.TryParse(Console.ReadLine(), out int employeeId);
    var employee = employeeRepository.GetById(employeeId);
    if (employee is null)
    {
        throw new Exception();
    }
    ViewStores();
    Console.WriteLine("select store id");
    int.TryParse(Console.ReadLine(), out int storeId);
    if (!storeRepository.DoesStoreExistById(storeId))
    {
        throw new Exception();
    }
    employee.StoreId = storeId;
    context.SaveChanges();
}

void EditEmployee()
{
    ViewAllEmployees();
    Console.WriteLine("select employee id");
    int.TryParse(Console.ReadLine(), out int employeeId);
    var employee = employeeRepository.GetById(employeeId);
    if (employee is null)
    {
        throw new Exception();
    }
    var user = userRepository.GetById(employee.UserId);
    if (user is null)
    {
        throw new Exception();
    }
    Console.WriteLine("Enter first name:");
    var firstName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(firstName))
    {
        throw new Exception();
    }
    if (firstName.Length>100)
    {
        throw new Exception();
    }
    Console.WriteLine("Enter last name:");
    var lastName = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(lastName))
    {
        throw new Exception();
    }
    if (lastName.Length>100)
    {
        throw new Exception();
    }
    Console.WriteLine("Enter Phone number:");
    var phoneNumber = Console.ReadLine();
    user.FirstName = firstName;
    user.LastName = lastName;
    user.PhoneNumber = phoneNumber;
    context.SaveChanges();
}

void DeleteEmployee()
{
    ViewAllEmployees();
    Console.WriteLine("select employee id");
    int.TryParse(Console.ReadLine(), out int employeeId);
    var employee = employeeRepository.GetById(employeeId);
    if (employee is null)
    {
        throw new Exception();
    }
    employeeRepository.Remove(employee);
    context.SaveChanges();
}

#endregion

