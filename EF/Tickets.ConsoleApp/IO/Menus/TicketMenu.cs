using Tickets.ConsoleApp.Constants;
using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.EfPersistence.Tickets;
using Tickets.ConsoleApp.EfPersistence.Trips;
using Tickets.ConsoleApp.Entities;
using Tickets.ConsoleApp.Exceptions;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class TicketMenu(EfDataContext dbContext, IUi ui)
    : MenuStructure(dbContext, ui)
{
    private readonly EfTripRepository _tripRepository =
        new EfTripRepository(dbContext);

    private readonly EfTicketRepository _ticketRepository =
        new EfTicketRepository(dbContext);

    protected override string ExitMessageMenu { get; } = "Back to main menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Buy Ticket", Create);
        MenuItems.Add("Show All", ShowAll);

        MenuItems.Add("Delete", Delete);
    }

    private void Create()
    {
        new UserMenu(dbContext, ui).ShowAll();
        var userId = ui.GetIntegerFromUser("Enter user Id: ");
        new TripMenu(dbContext, ui).ShowAllAvailableTrips();
        var tripId = ui.GetIntegerFromUser("Enter trip Id: ");
        var trip = _tripRepository.GetById(tripId)
                   ?? throw new NotFoundException(nameof(Trip), tripId);
        var newTicket = new Ticket
        {
            TripId = tripId,
            UserId = userId,
            BuyType =
                (BuyType)ui.GetIntegerFromUser(
                    "Enter buy type(1 to buy, 2 to Reserve): "),
        };
        decimal priceToPay = newTicket.BuyType == BuyType.Buy
            ? trip.PricePerTicket
            : (
                trip.PricePerTicket * (decimal)0.30);
        Pay(priceToPay);
        _ticketRepository.Create(newTicket);
        dbContext.SaveChanges();
    }

    private bool Pay(decimal price)
    {
        ui.ShowMessage($"You pay {price}");
        return true;
    }

    private void ShowAll()
    {
        var tickets = _ticketRepository.GetAll();
        tickets.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id : '{_.Id}', UserId : '{_.UserId}', BuyType : '{_.BuyType}',Paid : '{_.Paid}'");
        });
    }


    private void Delete()
    {
        ShowAll();
        var ticketId = ui.GetIntegerFromUser("Enter ticket Id: ");
        var ticket = _ticketRepository.GetById(ticketId)
                     ?? throw new NotFoundException(nameof(Ticket), ticketId);
        if (ticket.Trip.Date <= DateTime.Now)
            throw new Exception("Trip is Alredy started");
        var priceToRepay = ticket.BuyType == BuyType.Buy
            ? ticket.Trip.PricePerTicket * (decimal)0.80
            : 0;
        ui.ShowMessage($"You Get {priceToRepay}");
        _ticketRepository.Delete(ticket);
        dbContext.SaveChanges();
    }
}