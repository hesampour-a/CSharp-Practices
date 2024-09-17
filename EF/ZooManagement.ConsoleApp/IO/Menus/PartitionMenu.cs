using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.EfPersistence.Partitions;
using ZooManagement.ConsoleApp.Entities;
using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO.Menus;

public class PartitionMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfPartitionRepository _partitionRepository =
        new EfPartitionRepository(dbContext);
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
        new ZooMenu(dbContext, ui).ShowAll();
        int zooId = ui.GetIntegerFromUser("Enter Partition's ZooID: ");
        new AnimalMenu(dbContext, ui).ShowAll();
        int animalId = ui.GetIntegerFromUser("Enter Animal's ID: ");
        var newPartiton = new Partition
        {
            AnimalId = animalId,
            ZooId = zooId,
            AnimalCount =
                ui.GetIntegerFromUser("Enter Partition's Animals Count: "),
            Area = ui.GetIntegerFromUser("Enter Partitions Area: "),
            Description =
                ui.GetStringFromUser("Enter Partition's Description: "),
        };
        _partitionRepository.Create(newPartiton);
        dbContext.SaveChanges();
        ui.ShowMessage($"Id :{newPartiton.Id}");
    }

    public void ShowAll()
    {
        var partitons = _partitionRepository.GetAll();
        partitons.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id :{_.Id},AnimalCount: {_.AnimalCount},Area: {_.Area},Description: {_.Description},ZooId: {_.ZooId},AnimalId: {_.AnimalId}");
        });
    }

    private void Edit()
    {
        ShowAll();
        new AnimalMenu(dbContext, ui).ShowAll();
        int partitionId = ui.GetIntegerFromUser("Enter Partition's ID: ");
        var partition = _partitionRepository.GetById(partitionId)
                        ?? throw new NotFoundException(nameof(Partition),
                            partitionId);
        partition.AnimalId =
            ui.GetIntegerFromUser("Enter Partition's Animal's ID: ");
        partition.AnimalCount =
            ui.GetIntegerFromUser("Enter Partition's Animals Count: ");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        int partitionId = ui.GetIntegerFromUser("Enter Partition's ID: ");
        var partition = _partitionRepository.GetById(partitionId)
                        ?? throw new NotFoundException(nameof(Partition),
                            partitionId);
        _partitionRepository.Delete(partition);
        dbContext.SaveChanges();
    }
}