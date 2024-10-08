﻿using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.EfPersistence.Blocks;
using BuildingManagement.ConsoleApp.Entities;
using BuildingManagement.ConsoleApp.IO.Interfaces;
using Library.Ef.ConsoleApp.Exceptions;

namespace BuildingManagement.ConsoleApp.IO.Menus;

public class BlockMenu(IUi ui, EfDataContext dbContext) : MenuStructure(ui)
{
    private readonly EfBlockRepository _blockRepository =
        new EfBlockRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create new Block", CreateNewBlock);
        MenuItems.Add("Show All Blocks", ShowAllBlocks);
        MenuItems.Add("Edit Block", EditBlock);
        MenuItems.Add("Delete Block", DeleteBlock);
        MenuItems.Add("Show Report", ShowReport);
    }

    private void ShowReport()
    {
        var dtos = _blockRepository.GetBlockReport();
        dtos.ForEach(d =>
        {
            ui.ShowMessage($"Name : {d.Name},MaxFloorNumber: {d.MaxFloorNumber},UnitsCount: {d.UnitsCount},Costs {d.Costs.Count},FloorsCount: {d.FloorsCount}");
        });
    }

    private void CreateNewBlock()
    {
        var newBlock = new Block
        {
            Name = ui.GetStringFromUser("Enter new block's name:"),
            MaxFloorNumber =
                ui.GetIntegerFromUser("Enter new block's max floor:"),
        };
        _blockRepository.Create(newBlock);
        _blockRepository.Save();
    }

    public void ShowAllBlocks()
    {
        var blocks = _blockRepository.GetAll();

        blocks.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id}, Name: {_.Name}, FloorCount: {_.FloorCount}, MaxFloorNumber: {_.MaxFloorNumber}");
        });
    }

    private void DeleteBlock()
    {
        ShowAllBlocks();
        int blockId = ui.GetIntegerFromUser("Enter block's id:");
        var block = _blockRepository.GetById(blockId)
                    ?? throw new NotFoundException(nameof(Block), blockId);
        _blockRepository.Delete(block);
        _blockRepository.Save();
    }

    private void EditBlock()
    {
        ShowAllBlocks();
        int blockId = ui.GetIntegerFromUser("Enter block's id:");
        var block = _blockRepository.GetById(blockId)
                    ?? throw new NotFoundException(nameof(Block), blockId);
        block.Name = ui.GetStringFromUser("Enter block's name:");
        block.MaxFloorNumber =
            ui.GetIntegerFromUser("Enter block's max floor:");
        _blockRepository.Save();
    }
}