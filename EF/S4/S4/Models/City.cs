namespace S4.Models;

public class City
{
    public int Id { get; set; }
    public string Title { get; set; }
    //public Province Province { get; set; }
    public int ProvinceId { get; set; }
    //public List<School> Schools { get; set; }
}