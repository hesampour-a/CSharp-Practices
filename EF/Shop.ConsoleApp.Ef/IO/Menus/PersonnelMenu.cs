using Shop.ConsoleApp.Ef.Dtos.Personnels;
using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.EfPersistances.Personnels;
using Shop.ConsoleApp.Ef.EfPersistances.Users;
using Shop.ConsoleApp.Ef.Exceptions;
using Shop.ConsoleApp.Ef.IO.Interfaces;
using Shop.ConsoleApp.Ef.Models;

namespace Shop.ConsoleApp.Ef.IO.Menus;

public class PersonnelMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    EfPersonnelRepository personnelRepository =
        new EfPersonnelRepository(dbContext);

    EfUserRepository userRepository = new EfUserRepository(dbContext);

    public Dictionary<string, Action> MenuItems { get; set; } = [];

    public void AddMenuItems()
    {
        MenuItems.Add("Create New Personnel", CreatePersonnel);
        MenuItems.Add("Show All Personnels", ShowAllPersonnels);
        MenuItems.Add("Edit Personnel", EditPersonnel);
        MenuItems.Add("Delete Personnel", DeletePersonnel);
    }

    void CreatePersonnel()
    {
        var newUser = new User
        {
            Name = ui.GetStringFromUser("Enter name :"),
        };
        userRepository.Create(newUser);
        dbContext.SaveChanges();

        var newPersonnel = new Personnel
        {
            UserId = newUser.Id,
            PersonelCode = ui.GetIntegerFromUser("Enter personnel code :"),
        };
        personnelRepository.Create(newPersonnel);
        dbContext.SaveChanges();
    }

    void ShowAllPersonnels()
    {
        //left join
        var allPersonnels = personnelRepository.GetAllPersonnel();

        allPersonnels.ForEach(personnel =>
        {
            ui.ShowMessage(
                $"Personnel Id : {personnel.Id} , Personnel Name : {personnel.Name} ");
        });
    }


    void EditPersonnel()
    {
        int personnelId = ui.GetIntegerFromUser("Enter personnel id :");
        var personnel =
            personnelRepository.GetById(personnelId)
            ?? throw new NotFoundException(nameof(Personnel), personnelId);
        var user =
            userRepository.GetById(personnel.UserId);

        personnel.PersonelCode =
            ui.GetIntegerFromUser("Enter personnel's new code :");
        user.Name = ui.GetStringFromUser("Enter personnel's new name :");
        dbContext.SaveChanges();
    }

    void DeletePersonnel()
    {
        int personnelId = ui.GetIntegerFromUser("Enter personnel id :");
        var personnel =
           personnelRepository.GetById(personnelId)
            ?? throw new NotFoundException(nameof(Personnel), personnelId);
        personnelRepository.Delete(personnel);
        dbContext.SaveChanges();
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui, "Back to Main Menu").Start();
    }
}