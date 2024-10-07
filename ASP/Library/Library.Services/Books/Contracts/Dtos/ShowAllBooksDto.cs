namespace Library.Services.Books.Contracts.Dtos;

public class ShowAllBooksDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LendsCount { get; set; }
    public double AverageScore { get; set; }
}