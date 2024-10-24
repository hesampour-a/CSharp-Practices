using ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts.Dtos;

namespace ServiceCharge.Application.Floors.AddFloorAndUnits.Contracts;

public interface AddFloorAndUnitsHandler
{
    int AddSingleFloorWithUnits(int blockId, AddFloorAndUnitsDto dto);
}