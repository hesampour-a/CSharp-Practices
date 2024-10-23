using ServiceCharge.Service.Unit.Tests.Floors;
using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Services.Floors.Contracts;

public interface FloorService
{
    int Add(int blockId, FloorAddDto dto);
    void Update(int floorId, FloorUpdateDto dto);
    void Delete(int floorId);
}