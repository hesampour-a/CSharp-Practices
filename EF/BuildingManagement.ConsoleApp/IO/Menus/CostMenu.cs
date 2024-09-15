using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.EfPersistence.Blocks;
using BuildingManagement.ConsoleApp.EfPersistence.Costs;
using BuildingManagement.ConsoleApp.Entities;
using BuildingManagement.ConsoleApp.IO.Interfaces;
using Library.Ef.ConsoleApp.Exceptions;

namespace BuildingManagement.ConsoleApp.IO.Menus;

public class CostMenu(IUi ui, EfDataContext dbContext) : MenuStructure(ui)
{
    private readonly EfCostRepository _costRepository =
        new EfCostRepository(dbContext);

    private readonly EfBlockRepository _blockRepository =
        new EfBlockRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create new Cost", CreateCost);
        MenuItems.Add("Show all Costs", ShowAllCosts);
        MenuItems.Add("Edit Cost", EditCost);
        MenuItems.Add("Delete Cost", DeleteCost);
    }

    private void CreateCost()
    {
        int blockId = ui.GetIntegerFromUser("Enter Cost's Block ID: ");
        var block = _blockRepository.GetById(blockId)
                    ?? throw new NotFoundException(nameof(Block), blockId);
        var newCost = new Cost
        {
            BlockId = block.Id,
            Description = ui.GetStringFromUser("Enter Cost's Description: "),
            TotalCost = ui.GetDecimalFromUser("Enter Cost's Total Cost: "),
        };
        _costRepository.Create(newCost);
        dbContext.SaveChanges();
    }

    private void ShowAllCosts()
    {
        var costs = _costRepository.GetAll();
        costs.ForEach(cost =>
        {
            ui.ShowMessage(
                $"Id: {cost.Id}, Description: {cost.Description} Amount: {cost.TotalCost} BlockId: {cost.BlockId}");
        });
    }

    private void EditCost()
    {
        ShowAllCosts();
        int costId = ui.GetIntegerFromUser("Enter Cost's Id: ");
        var cost = _costRepository.GetById(costId)
                   ?? throw new NotFoundException(nameof(Cost), costId);
        //cost.BlockId = ui.GetIntegerFromUser("Enter Cost's Block ID: ");
        cost.Description = ui.GetStringFromUser("Enter Cost's Description: ");
        cost.TotalCost = ui.GetDecimalFromUser("Enter Cost's Total Cost: ");
        dbContext.SaveChanges();
    }

    private void DeleteCost()
    {
        ShowAllCosts();
        int costId = ui.GetIntegerFromUser("Enter Cost's Id: ");
        var cost = _costRepository.GetById(costId)
                   ?? throw new NotFoundException(nameof(Cost), costId);
        _costRepository.Delete(cost);
        dbContext.SaveChanges();
    }
}