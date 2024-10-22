using Library.Entities.Lends;
using Library.Entities.Rates;

namespace Library.Entities.Books;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Lend> Lends { get; set; } = [];
    public List<Rate> Rates { get; set; } = [];
}