namespace S2.Entities;

public class Hashtag
{
    public int Id { get; set; }
    public string Text { get; set; }
    public virtual Post Post { get; set; }
    public int PostId { get; set; }
    
}