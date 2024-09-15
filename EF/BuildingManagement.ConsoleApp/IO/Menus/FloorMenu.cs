using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.EfPersistence.Blocks;
using BuildingManagement.ConsoleApp.EfPersistence.Floors;
using BuildingManagement.ConsoleApp.Entities;
using BuildingManagement.ConsoleApp.IO.Interfaces;
using Library.Ef.ConsoleApp.Exceptions;

namespace BuildingManagement.ConsoleApp.IO.Menus;

public class FloorMenu(IUi ui, EfDataContext dbContext) : MenuStructure(ui)
{
    private readonly EfBlockRepository _blockRepository =
        new EfBlockRepository(dbContext);

    private readonly EfFloorRepository _floorRepository =
        new EfFloorRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create new Floor", CreateFloor);
        MenuItems.Add("Show All Floors", ShowAllFloors);
        MenuItems.Add("Edit Floor", EditFloor);
        MenuItems.Add("Delete Floor", DeleteFloor);
    }

    private void CreateFloor()
    {
        new BlockMenu(ui,dbContext).ShowAllBlocks();
        int blockId = ui.GetIntegerFromUser("Enter new Floor's Block Id");
        var block = _blockRepository.GetById(blockId)
                    ?? throw new NotFoundException(nameof(Block), blockId);
        if (block.Floors.Count == block.MaxFloorNumber)
            throw new ReachedMaxNumberException(blockId, nameof(Block),
                block.MaxFloorNumber);
        var newFloor = new Floor
        {
            BlockId = blockId,
            Name = ui.GetStringFromUser("Enter new Floor's Name"),
            MaxUnitNumber =
                ui.GetIntegerFromUser("Enter new Floor's Max Unit Number"),
        };
        _floorRepository.Create(newFloor);
        dbContext.SaveChanges();
    }

    public void ShowAllFloors()
    {
        var floors = _floorRepository.GetAll();
        floors.ForEach(_ =>
        {
            ui.ShowMessage($"id: {_.Id}, name: {_.Name}, block number: {_.BlockId}, Max Unit Number : {_.UnitsMaxNumber}");
        });
    }

    private void EditFloor()
    {
        ShowAllFloors();
        var floorId = ui.GetIntegerFromUser("Enter new Floor's Id");
        var floor = _floorRepository.GetById(floorId)
            ?? throw new NotFoundException(nameof(Floor), floorId);
        //floor.BlockId = ui.GetIntegerFromUser("Enter new Floor's Block Id");
        floor.MaxUnitNumber = ui.GetIntegerFromUser("Enter new Floor's Max Unit Number");
        floor.Name = ui.GetStringFromUser("Enter new Floor's Name");
    }

    private void DeleteFloor()
    {
        ShowAllFloors();
        var floorId = ui.GetIntegerFromUser("Enter new Floor's Id");
        var floor = _floorRepository.GetById(floorId)
                    ?? throw new NotFoundException(nameof(Floor), floorId);
        _floorRepository.Delete(floor);
        dbContext.SaveChanges();
    }
}