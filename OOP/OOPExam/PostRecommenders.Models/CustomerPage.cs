using PostRecommender.Contracts;

namespace PostRecommenders.Models;

internal class CustomerPage(string title,PageType pageType,int followerCount,decimal wallet = 1000)
{
    public string Title { get; init; } = title;
    public PageType PageType { get; init; } = pageType;
    public int FollowerCount { get; set; } = followerCount;
    public decimal Wallet { get; set; } = wallet;
    public List<Post> Posts { get; init; } = [];
}
