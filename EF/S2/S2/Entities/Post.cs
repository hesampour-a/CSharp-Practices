namespace S2.Entities;

public class Post
{
    public int Id { get; set; }
    public string Address { get; set; }
    public int LikeCount { get; set; }
    public virtual CustomerPage CustomerPage { get; set; }
    public int CustomerPageId { get; set; }
}