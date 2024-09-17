using ZooManagement.ConsoleApp.Entities;

namespace ZooManagement.ConsoleApp.EfPersistence.SoldTickets;

public class EfSoldTicketRepository(EfDataContext dbContext)
{
    public void Create(SoldTicket newSoldTicket)
    {
        dbContext.SoldTickets.Add(newSoldTicket);
    }
}