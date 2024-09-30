using Inheritance_Practice.BaseClasses;

namespace Inheritance_Practice.DrivedClasses;

public class Seller(string name, string address) : User(name, address)
{
    public string Sell(string productName, string customerName)
         => $"{Name} sold {productName} to {customerName}";
}