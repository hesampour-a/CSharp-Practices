using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.EfPersistence.Animals;
using ZooManagement.ConsoleApp.Entities;
using ZooManagement.ConsoleApp.Exceptions;
using ZooManagement.ConsoleApp.IO.Interfaces;

namespace ZooManagement.ConsoleApp.IO.Menus;

public class AnimalMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfAnimalRepository _animalRepository =
        new EfAnimalRepository(dbContext);

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
        var newAnimal = new Animal
        {
            Title = ui.GetStringFromUser("Enter animal name"),
        };
        if (_animalRepository.Exists(newAnimal.Title))
            throw new Exception($"Animal already exists: {newAnimal.Title}");
        _animalRepository.Create(newAnimal);
        dbContext.SaveChanges();
        ui.ShowMessage($"animal created with Id : {newAnimal.Id}");
    }

    public void ShowAll()
    {
        var animals = _animalRepository.GetAll();
        animals.ForEach(_ =>
        {
            ui.ShowMessage($"Id :{_.Id} :Title {_.Title}");
        });
    }

    private void Edit()
    {
        ShowAll();
        int animalId = ui.GetIntegerFromUser("Enter animal id");
        var animal = _animalRepository.GetById(animalId)
                     ?? throw new NotFoundException(nameof(Animal), animalId);
        animal.Title = ui.GetStringFromUser("Enter animal name");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        int animalId = ui.GetIntegerFromUser("Enter animal id");
        var animal = _animalRepository.GetById(animalId)
                     ?? throw new NotFoundException(nameof(Animal), animalId);
        _animalRepository.Delete(animal);
        dbContext.SaveChanges();
    }
}