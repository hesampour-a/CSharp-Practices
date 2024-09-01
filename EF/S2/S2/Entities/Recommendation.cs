namespace S2.Entities;

public class Recommendation
{
    public int Id { get; set; }
    public virtual Post Post { get; set; }
    public int PostId { get; set; }
    public virtual Follower Follower { get; set; }
    public int FollowerId { get; set; }
}