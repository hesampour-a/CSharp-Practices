using Library.Entities.Books;
using Library.Entities.Users;

namespace Library.Entities.Lends;

public class Lend
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public User User { get; set; }
    public Book Book { get; set; }
    public DateOnly LendDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}