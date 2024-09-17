using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.EfPersistence.SoldTickets;
using ZooManagement.ConsoleApp.EfPersistence.Tickets;
using ZooManagement.ConsoleApp.Entities;
using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO.Menus;

public class TicketMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfTicketRepository _ticketRepository =
        new EfTicketRepository(dbContext);

    private readonly EfSoldTicketRepository _soldTicketRepository =
        new EfSoldTicketRepository(dbContext);
    protected override string ExitMessageMenu { get; } = "Back to main menu";
    protected override void AddMenuItems()
    {
        MenuItems.Add("Create", Create);
        MenuItems.Add("Show All", ShowAll);
        MenuItems.Add("Edit", Edit);
        MenuItems.Add("Delete", Delete);
        MenuItems.Add("Buy", BuyTicket);
    }

    private void BuyTicket()
    {
        ShowAll();
        int ticketId = ui.GetIntegerFromUser("Enter Ticket ID: ");
        var ticket = _ticketRepository.GetById(ticketId)
                     ?? throw new NotFoundException(nameof(Ticket), ticketId);
        var newSoldTicket = new SoldTicket
        {
            TicketId = ticketId,
        };

        if (!GetMoney(ticket.Price))
            throw new Exception("Failed to buy ticket");
        _soldTicketRepository.Create(newSoldTicket);
        dbContext.SaveChanges();
    }

    bool GetMoney(decimal money)
    {
        ui.ShowMessage($"Pay {money}");
        return true;
    }

    private void Create()
    {
        new PartitionMenu(dbContext, ui).ShowAll();
        int partitionId =
            ui.GetIntegerFromUser("Enter Ticket's Partition ID: ");
        var newTicket = new Ticket
        {
            PartitionId = partitionId,
            Price = ui.GetDecimalFromUser("Enter Ticket's Price: "),
        };
        if (_ticketRepository.ExistsForPartition(partitionId))
            throw new Exception(
                $"Ticket with partition ID {partitionId} already exists");
        _ticketRepository.Create(newTicket);
        dbContext.SaveChanges();
        ui.ShowMessage($"Ticket Created with Id{newTicket.Id}");
    }

    private void ShowAll()
    {
        var tickets = _ticketRepository.GetAll();
        tickets.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id},Price: {_.Price},PartitionId: {_.PartitionId}");
        });
    }

    private void Edit()
    {
        ShowAll();
        int ticketId = ui.GetIntegerFromUser("Enter Ticket's Id: ");
        var ticket = _ticketRepository.GetById(ticketId)
                     ?? throw new NotFoundException(nameof(Ticket), ticketId);
        ticket.Price = ui.GetDecimalFromUser("Enter Ticket's Price: ");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        int ticketId = ui.GetIntegerFromUser("Enter Ticket's Id: ");
        var ticket = _ticketRepository.GetById(ticketId)
                     ?? throw new NotFoundException(nameof(Ticket), ticketId);
        _ticketRepository.Delete(ticket);
        dbContext.SaveChanges();
    }
}