using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.EfPersistence.Trips;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui)
    : MenuStructure(dbContext, ui)
{
    private readonly EfTripRepository _tripRepository =
        new EfTripRepository(dbContext);

    protected override void AddMenuItems()
    {
        MenuItems.Add("Show User Menu", ShowUserMenu);
        MenuItems.Add("Show Bus Menu", ShowBusMenu);
        MenuItems.Add("Show Trip Menu", ShowTripMenu);
        MenuItems.Add("Show Ticket Menu", ShowTicketMenu);
        MenuItems.Add("Show City Input Report", ShowCityInputReport);
        MenuItems.Add("Show City Output Report", ShowCityOutputReport);
    }


    private void ShowUserMenu()
    {
        new UserMenu(dbContext, ui).Show();
    }

    private void ShowBusMenu()
    {
        new BusMenu(dbContext, ui).Show();
    }

    private void ShowTripMenu()
    {
        new TripMenu(dbContext, ui).Show();
    }

    private void ShowTicketMenu()
    {
        new TicketMenu(dbContext, ui).Show();
    }

    private void ShowCityInputReport()
    {
        var cities = _tripRepository.GetCityInputReport();
        cities.ForEach(_ =>
        {
            ui.ShowMessage($"City: {_.Name} , Count: {_.Count}");
        });
    }

    private void ShowCityOutputReport()
    {
        var cities = _tripRepository.GetCityOutputReport();
        cities.ForEach(_ =>
        {
            ui.ShowMessage($"City: {_.Name} , Count: {_.Count}");
        });
    }
}