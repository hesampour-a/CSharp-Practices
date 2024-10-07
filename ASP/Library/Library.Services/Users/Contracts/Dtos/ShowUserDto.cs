namespace Library.Services.Users.Contracts.Dtos;

public class ShowUserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly JoinDate { get; set; }
}