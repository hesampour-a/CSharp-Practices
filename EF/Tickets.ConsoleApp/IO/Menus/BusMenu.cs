using Tickets.ConsoleApp.Constants;
using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.EfPersistence.Buses;
using Tickets.ConsoleApp.Entities;
using Tickets.ConsoleApp.Exceptions;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class BusMenu(EfDataContext dbContext, IUi ui)
    : MenuStructure(dbContext, ui)
{
    private readonly EfBusRepository _busRepository =
        new EfBusRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create", Create);
        MenuItems.Add("Show All", ShowAll);
        MenuItems.Add("Edit", Edit);
        MenuItems.Add("Delete", Delete);
    }

    private void Create()
    {
        var newBus = new Bus
        {
            Plaque = ui.GetStringFromUser("Enter Bus Plaque :"),
            BusType =
                (BusType)ui.GetIntegerFromUser(
                    "Enter Bus Type(1 for Economy , 2 for Vip) :"),
        };
        _busRepository.Create(newBus);
        dbContext.SaveChanges();
    }

    public void ShowAll()
    {
        var buses = _busRepository.GetAll();
        buses.ForEach(b =>
        {
            ui.ShowMessage($"Id : {b.Id}, Plaque : {b.Plaque}, BusType : {b.BusType}");
        });
    }

    private void Edit()
    {
        ShowAll();
        var busId = ui.GetIntegerFromUser("Enter Bus Id:");
        var bus = _busRepository.GetById(busId)
            ?? throw new NotFoundException(nameof(Bus), busId);
        bus.Plaque = ui.GetStringFromUser("Enter Bus Plaque:");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        var busId = ui.GetIntegerFromUser("Enter Bus Id:");
        var bus = _busRepository.GetById(busId)
                  ?? throw new NotFoundException(nameof(Bus), busId);
        _busRepository.Delete(bus);
        dbContext.SaveChanges();
        
    }
}