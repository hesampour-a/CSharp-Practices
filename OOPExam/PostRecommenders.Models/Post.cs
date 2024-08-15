namespace PostRecommenders.Models;

internal class Post(string address,int likeCount,List<string> hastags)
{

    public string PostAddress { get; init; } = address;

    public int LikeCount { get; set; } = likeCount;

    public List<string> Hashtags { get; set; } = hastags;
}
