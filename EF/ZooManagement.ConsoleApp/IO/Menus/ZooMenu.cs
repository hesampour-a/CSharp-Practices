using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.EfPersistence.Zooes;
using ZooManagement.ConsoleApp.Entities;
using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO.Menus;

public class ZooMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfZooRepository _zooRepository =
        new EfZooRepository(dbContext);
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
        var newZoo = new Zoo
        {
            Name = ui.GetStringFromUser("Enter Zoo Name"),
            Address = ui.GetStringFromUser("Enter Zoo Address"),
        };
        _zooRepository.Create(newZoo);
        dbContext.SaveChanges();
        ui.ShowMessage(newZoo.Id.ToString());
    }

    public void ShowAll()
    {
        var zooes = _zooRepository.GetAll();
        zooes.ForEach(_ =>
        {
            ui.ShowMessage(
                $"Id: {_.Id}, Name: {_.Name}, Address: {_.Address}");
        });
    }

    private void Edit()
    {
        ShowAll();
        int zooId = ui.GetIntegerFromUser("Enter Zoo ID");
        var zoo = _zooRepository.GetById(zooId)
                  ?? throw new NotFoundException(nameof(Zoo), zooId);
        zoo.Name = ui.GetStringFromUser("Enter Zoo Name");
        zoo.Address = ui.GetStringFromUser("Enter Zoo Address");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        int zooId = ui.GetIntegerFromUser("Enter Zoo ID");
        var zoo = _zooRepository.GetById(zooId)
                  ?? throw new NotFoundException(nameof(Zoo), zooId);
        _zooRepository.Delete(zoo);
        dbContext.SaveChanges();
    }
}