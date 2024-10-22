using Library.Entities.Books;

namespace Library.Entities.Rates;

public class Rate
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Score { get; set; }
}