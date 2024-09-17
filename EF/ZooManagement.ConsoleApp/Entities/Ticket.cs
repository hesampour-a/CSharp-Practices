namespace ZooManagement.ConsoleApp.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int PartitionId { get; set; }
    public Partition Partition { get; set; }
    public decimal Price { get; set; }
    public List<SoldTicket> SoldTickets { get; set; }
}