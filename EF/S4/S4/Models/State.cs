namespace S4.Models;

public class State
{
    public int Id { get; set; }
    public string Title { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public List<City> Cities { get; set; }
}