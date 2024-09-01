namespace S2.Entities;

public class FollowerIntrestedHashtag
{
    public int Id { get; set; }
    public virtual Hashtag Hashtag { get; set; }
    public int HashtagId { get; set; }
    public virtual Follower Follower { get; set; }
    public int FollowerId { get; set; }
}