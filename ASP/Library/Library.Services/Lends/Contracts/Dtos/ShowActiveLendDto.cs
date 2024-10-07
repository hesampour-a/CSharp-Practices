namespace Library.Services.Lends.Contracts.Dtos;

public class ShowActiveLendDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string BookName { get; set; }
    public DateOnly LendDate { get; set; }
    public DateOnly ReturnDate { get; set; }
}