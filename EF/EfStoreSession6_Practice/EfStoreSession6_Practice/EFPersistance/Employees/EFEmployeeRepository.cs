using EfStoreSession6_Practice.Dtos.Employees;
using EfStoreSession6_Practice.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfStoreSession6_Practice.EFPersistance.Employees;

public class EFEmployeeRepository(EFDataContext context)
{
    public void Add(Employee employee)
    {
        context.Set<Employee>().Add(employee);
    }

    public List<GetAllEmployeesDto> GetAll()
    {
        return (
            from employee in context
                .Set<Employee>()
            join user in context.Set<User>()
                on employee.UserId equals user.Id
                join store in context.Set<Store>()
                on employee.StoreId equals store.Id
                into storeEmployees
            from storeEmployee in storeEmployees.DefaultIfEmpty()
            select new GetAllEmployeesDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmployeeId = employee.Id,
                PersonnelNumber = employee.PersonnelNumber,
                StoreName = storeEmployee != null? storeEmployee.Name : "unemployed"
            }).ToList();
    }

    public Employee? GetById(int id)
    {
        return context.Set<Employee>().FirstOrDefault(_ => _.Id == id);
    }

    public void Remove(Employee employee)
    {
        context.Set<Employee>().Remove(employee);
    }
}