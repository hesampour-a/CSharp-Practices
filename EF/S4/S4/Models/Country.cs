namespace S4.Models;

public class Country
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<State> States { get; set; }
}