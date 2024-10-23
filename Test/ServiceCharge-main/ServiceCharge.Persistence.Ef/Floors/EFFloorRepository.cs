using ServiceCharge.Entities;
using ServiceCharge.Services.Floors.Contracts;

namespace ServiceCharge.Persistence.Ef.Floors;

public class EFFloorRepository(EfDataContext context) : FloorRepository
{
    public void Add(Floor floor)
    {
        context.Set<Floor>().Add(floor);
    }

    public Floor? Find(int floorId)
    {
        return context.Set<Floor>().FirstOrDefault(_ => _.Id == floorId);
    }

    public int UnitsCount(int floorId)
    {
        // return
        //     (from floors in context.Set<Floor>()
        //         where floors.Id == floorId
        //         join units in context.Set<Unit>()
        //             on floors.Id equals units.FloorId
        //         select new
        //         {
        //             units.Id,
        //         }).Count();
        return context
            .Set<Unit>()
            .Count(_ => _.FloorId == floorId);
    }

    public void Update(Floor floor)
    {
        context.Set<Floor>().Update(floor);
    }

    public void Delete(Floor floor)
    {
        context.Set<Floor>().Remove(floor);
    }
}