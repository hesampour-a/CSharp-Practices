namespace S4.Models;

public class City
{
    public int Id { get; set; }
    public string Title { get; set; }
    public State State { get; set; }
    public int StateId { get; set; }
}