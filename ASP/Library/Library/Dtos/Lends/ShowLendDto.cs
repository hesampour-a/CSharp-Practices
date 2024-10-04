namespace Library.Dtos.Lends;

public class ShowLendDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateOnly LendDate { get; set; }
    public DateOnly ReturnDate { get; set; }
    public bool IsReturned { get; set; }
}