using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.EfPersistence.Partitions;
using ZooManagement.ConsoleApp.EfPersistence.Zooes;
using ZooManagement.ConsoleApp.Entities;
using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfZooRepository _zooRepository =
        new EfZooRepository(dbContext);

    private readonly EfPartitionRepository _partitionRepository =
        new EfPartitionRepository(dbContext);

    protected override void AddMenuItems()
    {
        MenuItems.Add("Show Zoo Menu", ShowZooMenu);
        MenuItems.Add("Show Animal Menu", ShowAnimalMenu);
        MenuItems.Add("Show Partition Menu", ShowPartitionMenu);
        MenuItems.Add("Show Ticket Menu", ShowTicketMenu);
        MenuItems.Add("Show Zooes with Animals", ShowReport1);
        MenuItems.Add("Show Zooes with Partitions", ShowReport2);
        MenuItems.Add("Show Partitions with animals", ShowReport3);
        MenuItems.Add("Show Sold Tickets for partitions order by count",
            ShowReport4);
        MenuItems.Add("Show Sold Tickets for partitions order by totoal cost",
            ShowReport5);
    }

    private void ShowReport1()
    {
        var zooes = _zooRepository.GetReport1();
        zooes.ForEach(zoo =>
        {
            ui.ShowMessage(
                $"Name : {zoo.Name},Address: {zoo.Address} Animals:");
            zoo.Animals.ForEach(animal =>
            {
                ui.ShowMessage($"Id: {animal.Id}, Name: {animal.Title}");
            });
        });
    }

    private void ShowReport2()
    {
        var zooes = _zooRepository.GetReport2();
        zooes.ForEach(zoo =>
        {
            ui.ShowMessage(
                $"Name: {zoo.Name},PartitionsCount: {zoo.PartitionsCount}, Partitions:");
            zoo.Partitons.ForEach(p =>
            {
                ui.ShowMessage(
                    $"Area : {p.Area}, TicketPrice: {p.TicketPrice}");
            });
        });
    }

    private void ShowReport3()
    {
        var partitions = _partitionRepository.GetReport3();
        partitions.ForEach(p =>
        {
            ui.ShowMessage(
                $"Id: {p.Id},AnimalCount: {p.AnimalCount},AnimalName: {p.AnimalName},Description: {p.Description}");
        });
    }

    private void ShowReport4()
    {
        new ZooMenu(dbContext, ui).ShowAll();
        int zooId = ui.GetIntegerFromUser("Enter Zoo Id:");
        var zoo = _zooRepository.GetById(zooId)
                  ?? throw new NotFoundException(nameof(Zoo), zooId);
        var partitions = _partitionRepository.GetReport4(zooId);
        partitions.ForEach(_ =>
        {
            ui.ShowMessage(
                $"PartitionId : {_.PartitionId}, Sold Ticket Count: {_.SoldTicketCount}");
        });
    }

    private void ShowReport5()
    {
        new ZooMenu(dbContext, ui).ShowAll();
        int zooId = ui.GetIntegerFromUser("Enter Zoo Id:");
        var zoo = _zooRepository.GetById(zooId)
                  ?? throw new NotFoundException(nameof(Zoo), zooId);
        var partitions = _partitionRepository.GetReport5(zooId);
        partitions.ForEach(p =>
        {
            ui.ShowMessage(
                $"Partition : {p.PartitionId}, Total Sold Cost{p.TotalSellCost}");
        });
    }

    private void ShowZooMenu()
    {
        new ZooMenu(dbContext, ui).Show();
    }

    private void ShowAnimalMenu()
    {
        new AnimalMenu(dbContext, ui).Show();
    }

    private void ShowPartitionMenu()
    {
        new PartitionMenu(dbContext, ui).Show();
    }

    private void ShowTicketMenu()
    {
        new TicketMenu(dbContext, ui).Show();
    }
}