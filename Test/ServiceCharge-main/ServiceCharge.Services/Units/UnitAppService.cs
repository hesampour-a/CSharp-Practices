using ServiceCharge.Services.UnitOfWorks;
using ServiceCharge.Services.Units.Contracts;
using ServiceCharge.Services.Units.Exceptions;

namespace ServiceCharge.Services.Units;

public class UnitAppService(
    UnitRepository unitRepository,
    UnitOfWork unitOfWork) : UnitService
{
    public void Delete(int unitId)
    {
        var unit = unitRepository.Find(unitId)
                   ?? throw new UnitNotFoundException();

        unitRepository.Delete(unit);
        unitOfWork.Save();
    }
}