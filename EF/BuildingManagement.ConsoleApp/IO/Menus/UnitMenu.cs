using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.EfPersistence.Floors;
using BuildingManagement.ConsoleApp.EfPersistence.Units;
using BuildingManagement.ConsoleApp.Entities;
using BuildingManagement.ConsoleApp.IO.Interfaces;
using Library.Ef.ConsoleApp.Exceptions;

namespace BuildingManagement.ConsoleApp.IO.Menus;

public class UnitMenu(IUi ui, EfDataContext dbContext) : MenuStructure(ui)
{
    private readonly EfFloorRepository _floorRepository =
        new EfFloorRepository(dbContext);

    private readonly EfUnitRepository _unitRepository =
        new EfUnitRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create new Unit", CreateUnit);
        MenuItems.Add("Show all Units", ShowAllUnits);
        MenuItems.Add("Edit Unit", EditUnit);
        MenuItems.Add("Delete Unit", DeleteUnit);
    }

    private void CreateUnit()
    {
        new FloorMenu(ui, dbContext).ShowAllFloors();
        var floorId = ui.GetIntegerFromUser("Enter floor ID");
        var floor = _floorRepository.GetById(floorId)
                    ?? throw new NotFoundException(nameof(Floor), floorId);
        if (floor.Units.Count == floor.MaxUnitNumber)
            throw new ReachedMaxNumberException(floorId, nameof(Floor),
                floor.MaxUnitNumber);
        var newUnit = new Unit
        {
            FloorId = floorId,
            Name = ui.GetStringFromUser("Enter unit name"),
        };
        _unitRepository.Create(newUnit);
        dbContext.SaveChanges();
    }

    private void ShowAllUnits()
    {
        var units = _unitRepository.GetAll();
        units.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id}, Name: {_.Name}, FloorId: {_.FloorId}");
        });
    }

    private void EditUnit()
    {
        ShowAllUnits();
        int unitId = ui.GetIntegerFromUser("Enter unit ID");
        var unit = _unitRepository.GetById(unitId)
                   ?? throw new NotFoundException(nameof(Unit), unitId);
        unit.Name = ui.GetStringFromUser("Enter unit name");
        dbContext.SaveChanges();
    }

    private void DeleteUnit()
    {
        ShowAllUnits();
        int unitId = ui.GetIntegerFromUser("Enter unit ID");
        var unit = _unitRepository.GetById(unitId)
                   ?? throw new NotFoundException(nameof(Unit), unitId);
        _unitRepository.Delete(unit);
        dbContext.SaveChanges();
    }
}