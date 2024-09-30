using Inheritance_Practice.DrivedClasses;

var seller = new Seller("Karim", "Karaj"); //base calss = User
Console.WriteLine(seller.Sell("Laptop", "Ahmed"));


var emploee = new Emploee("Ahmed", "Karaj", 1000000, 10); //base calss = User
Console.WriteLine(emploee.Work());


var programmer = new Programmer("Hamid", "Shiraz", 9000000, 12, "C#"); //base calss = Employee
Console.WriteLine(programmer.Code());