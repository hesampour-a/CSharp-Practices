using Library.Entities.Lends;

namespace Library.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateOnly JoinDate { get; set; }
    public List<Lend> Lends { get; set; } = [];
}