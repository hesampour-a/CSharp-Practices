using S3.Data;
using S3.Models;

var context = new EfDataContext();

var student = new Student
{
    Name = "John Doe",
};

context.Students.Add(student);
context.SaveChanges();