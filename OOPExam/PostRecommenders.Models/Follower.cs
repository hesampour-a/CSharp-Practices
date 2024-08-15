using PostRecommender.Contracts;

namespace PostRecommenders.Models;

internal class Follower(string pageAddress,string title)
{
    public string PageAddress { get; init; } = pageAddress;
    public string Title { get; init; } = title;
    public List<string> InterestedHashtags { get; init; } = [];
    public List<PageType> InterestedTypes { get; set; } = [];
   // public InterestPageType InterestPageType { get; set; }

}

//public enum InterestPageType
//{
//    Personal = 1,
//    Business,
//    Both
//}