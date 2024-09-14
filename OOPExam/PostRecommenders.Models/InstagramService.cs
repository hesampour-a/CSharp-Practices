using PostRecommender.Contracts;

namespace PostRecommenders.Models;

public class InstagramService : IInstagramPageService
{
    private readonly List<CustomerPage> _customerPages = [];
    private readonly List<Follower> _followers = [];
    private readonly List<Recommendation> _recommendations = [];
    private decimal totalIncom = 0;

    public void RechargeCustomerWallet(WalletRechargeDto walletRechargeDto)
    {
        _customerPages[walletRechargeDto.CustomerId - 1].Wallet += walletRechargeDto.Amount;
    }

    public void RecommendCustomerPosts(RecommendCustomerPostsDto recommendCustomerPostsDto)
    {
        var customer = _customerPages[recommendCustomerPostsDto.CustomerId - 1];
        decimal payPerRecommend = customer.PageType == PageType.Personal ? 10 : 100;
        _followers.ForEach(follower =>
        {
            if (!follower.InterestedTypes.Contains(customer.PageType)) return;
            var posts = customer.Posts.Where(p => p.Hashtags.Any(c => follower.InterestedHashtags.Contains(c)))
                .ToList();
            posts.ForEach(post =>
            {
                if (customer.Wallet >= payPerRecommend)
                {
                    _recommendations.Add(new Recommendation
                    {
                        Follower = follower,
                        Post = post,
                    });
                    customer.Wallet -= payPerRecommend;
                    totalIncom += payPerRecommend;
                }
            });
        });
    }

    public void RegisterCustomerPage(RegisterCustomerPageDto registerCustomerPageDto)
    {
        if (registerCustomerPageDto.FollowerCount < 10)
            throw new Exception("you need at least 10 follower");
        _customerPages.Add(
            new
                CustomerPage
                (
                    registerCustomerPageDto.Title,
                    registerCustomerPageDto.PageType,
                    registerCustomerPageDto.FollowerCount
                ));
    }

    public void RegisterCustomerPost(RegisterCustomerPostDto registerCustomerPostDto)
    {
        if (registerCustomerPostDto.LikeCount >= 5 && registerCustomerPostDto.Hashtags.Count() >= 1)
            _customerPages[registerCustomerPostDto.CustomerId - 1].Posts.Add(new Post(
                registerCustomerPostDto.PostAddress, registerCustomerPostDto.LikeCount,
                registerCustomerPostDto.Hashtags));
    }

    public void RegisterFollower(RegisterFollowerDto registerFollowerDto)
    {
        _followers.Add(new Follower(registerFollowerDto.PageAddress, registerFollowerDto.Title));
    }

    public void RegisterFollowerLikedPost(RegisterFollowerLikedPostDto registerFollowerLikedPostDto)
    {
        var follower = _followers[registerFollowerLikedPostDto.FollowerId - 1];
        registerFollowerLikedPostDto.PostHashtags.ForEach(_ =>
        {
            if (!(follower.InterestedHashtags.Any(hastag => _ == hastag)))
                follower.InterestedHashtags.Add(_);
        });

        if (!(follower.InterestedTypes.Any(_ => _ == registerFollowerLikedPostDto.LikedPageType)))
            follower.InterestedTypes.Add(registerFollowerLikedPostDto.LikedPageType);
    }

    public List<RecommendationDto> ShowCustomerRecommendations(RecommendationRequestDto recommendationRequestDto)
    {
        var list = new List<RecommendationDto>();
        var customer = _customerPages[recommendationRequestDto.CustomerId - 1];
        decimal payPerRecommend = customer.PageType == PageType.Personal ? 30 : 300;
        if (customer.Wallet >= payPerRecommend)
        {
            totalIncom += payPerRecommend;
            customer.Wallet -= payPerRecommend;
            var recommends = _followers.SelectMany(_ => _.InterestedHashtags).GroupBy(_ => _).Select(_ => new
            {
                InterestedHashtag = _.Key,
                Count = _.Count()
            }).OrderByDescending(_ => _.Count).Select(_ => _.InterestedHashtag).ToList();

            list.Add(new RecommendationDto { Hashtags = recommends });
        }

        return list;
    }


    public List<ShowCustomerPageDto> ShowCustomersPage()
    {
        return _customerPages.Select((_, Index) => new ShowCustomerPageDto
        {
            Id = Index + 1,
            FollowerCount = _.FollowerCount,
            PageType = _.PageType,
            Title = _.Title,
            WalletBalance = _.Wallet
        }).ToList();
    }

    public List<ShowFollowerDto> ShowFollowers()
    {
        return _followers.Select((_, Index) => new ShowFollowerDto
        {
            FollowerId = Index + 1,
            Title = _.Title,
            PageAddress = _.PageAddress
        }).ToList();
    }

    public ShowTotalIncomeDto ShowTotalIncome()
    {
        return new ShowTotalIncomeDto
        {
            TotalIncome = totalIncom
        };
    }

    public void UpdateCustomerFollowerCount(UpdateFollowerCountDto updateFollowerCountDto)
    {
        _customerPages[updateFollowerCountDto.CustomerId - 1].FollowerCount = updateFollowerCountDto.NewFollowerCount;
    }
}