using System.Threading.Channels;
using EFSession1;
using EFSession1.Models;

var context = new EFDataContext();

var teacher = new Teacher
{
    YearsOfService = 1,
    PersonelId = "4562154221",
    User = new User
    {
    FirstName = "siavash",
    LastName = "nabipour",
    NationalId = "21452145",
    PhoneNumber = "9172036054",
    Email = "siavashnabipour@gmail.com"
}
};

context.Set<Teacher>().Add(teacher);
context.SaveChanges();

Console.WriteLine("end of program");