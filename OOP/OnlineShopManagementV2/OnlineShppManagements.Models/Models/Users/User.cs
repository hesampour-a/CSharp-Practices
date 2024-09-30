using OnlineShppManagements.Models.Interfaces;

namespace OnlineShppManagements.Models.Models.Users;

public class User(string name) : IHasId
{
    public int Id { get; set; }
    public string Name { get; set; } = name;
}
