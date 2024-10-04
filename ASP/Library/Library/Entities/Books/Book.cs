using Library.Entities.Lends;

namespace Library.Entities.Books;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Lend> Lends { get; set; } = [];
}