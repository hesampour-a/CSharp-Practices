using Play_Ground;

var persia = new Car("persia");

persia.HandBreakEngaged = false;

Console.WriteLine(persia.Drive());
Console.WriteLine(persia.Brake());


persia.HandBreakEngaged = true;


Console.WriteLine(persia.Drive());
Console.WriteLine(persia.Brake());
