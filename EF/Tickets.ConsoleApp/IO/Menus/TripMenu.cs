using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.EfPersistence.Trips;
using Tickets.ConsoleApp.Entities;
using Tickets.ConsoleApp.Exceptions;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class TripMenu(EfDataContext dbContext, IUi ui)
    : MenuStructure(dbContext, ui)
{
    private readonly EfTripRepository _tripRepository =
        new EfTripRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create", Create);
        MenuItems.Add("Show All", ShowAllAvailableTrips);
        MenuItems.Add("Edit", Edit);
        MenuItems.Add("Delete", Delete);
    }

    private void Create()
    {
        new BusMenu(dbContext, ui).ShowAll();
        var busId = ui.GetIntegerFromUser("Enter Trip's Bus ID: ");
        var newTrip = new Trip
        {
            BusId = busId,
            Date = ui.GetDateTimeFromUser("Enter Trip's Date: "),
            OriginCity = ui.GetStringFromUser("Enter Trip's Origin City: "),
            DestinationCity =
                ui.GetStringFromUser("Enter Trip's Destination City: "),
            PricePerTicket = ui.GetDecimalFromUser("Enter Trip's Price: "),
        };
        if (newTrip.Date <= DateTime.Now)
            throw new Exception($"Trip {newTrip.Date} is in the past.");

        _tripRepository.Create(newTrip);
        dbContext.SaveChanges();
        ui.ShowMessage($"Trip Created with Id : {newTrip.Id}");
    }

    public void ShowAllAvailableTrips()
    {
        var availableTrips = _tripRepository.GetAllAvailable();
        availableTrips.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id},Date: {_.Date},OriginCity: {_.OriginCity},DestinationCity: {_.DestinationCity},PricePerTicket: {_.PricePerTicket}");
        });
    }

    private void Edit()
    {
        ShowAllAvailableTrips();
        var tripId = ui.GetIntegerFromUser("Enter Trip Id :");
        var trip = _tripRepository.GetById(tripId)
                   ?? throw new NotFoundException(nameof(Trip), tripId);
        trip.OriginCity = ui.GetStringFromUser("Enter Trip's Origin City: ");
        trip.DestinationCity =
            ui.GetStringFromUser("Enter Trip's Destination City: ");
        trip.Date = ui.GetDateTimeFromUser("Enter Trip's Date: ");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAllAvailableTrips();
        var tripId = ui.GetIntegerFromUser("Enter Trip Id :");
        var trip = _tripRepository.GetById(tripId)
                   ?? throw new NotFoundException(nameof(Trip), tripId);
        _tripRepository.Delete(trip);
        dbContext.SaveChanges();
    }
}