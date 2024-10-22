namespace Library.Services.Users.Contracts.Dtos;

public class ShowAllUsersDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinDate { get; set; }
    public decimal Penalty { get; set; }
}