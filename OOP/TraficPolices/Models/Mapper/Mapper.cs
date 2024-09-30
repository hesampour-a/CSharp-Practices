using Models.Roads;

namespace Models.Mapper;

public static class Mapper
{
    public static RoadDto CreateRoadDto(this Road road)
    {
        return new RoadDto
        {
            StartPoint = road.StratPoint,
            EndPoint = road.EndPoint,
        };
    }
}
