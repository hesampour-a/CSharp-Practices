using PostRecommender.Contracts;

namespace PostRecommenders.Models;

internal class Recommendation
{
    public Post Post { get; init; }
    public Follower Follower { get; init; }

}
