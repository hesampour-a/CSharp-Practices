using ServiceCharge.Services.Floors.Contracts.Dtos;

namespace ServiceCharge.Services.Floors.Contracts;

public interface FloorQuery
{
    List<GetAllFloorsDto> GetAll();
    List<GetAllFloorsWithUnitsDto> GetAllWithUnits();
}