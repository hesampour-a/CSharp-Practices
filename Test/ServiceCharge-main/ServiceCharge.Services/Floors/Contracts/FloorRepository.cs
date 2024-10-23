using ServiceCharge.Entities;

namespace ServiceCharge.Services.Floors.Contracts;

public interface FloorRepository
{
    
    void Add(Floor floor);
    Floor? Find(int floorId);
    int UnitsCount(int floorId);
    void Update(Floor floor);
    void Delete(Floor floor);
}