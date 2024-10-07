using Library.Entities.Books;
using Library.Entities.Lends;
using Library.Entities.Users;

namespace Library.Entities.Rates;

public class Rate
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Score { get; set; }
}