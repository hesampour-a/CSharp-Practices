using Esmaeel.ConsoleApp.EfPersistence;
using Esmaeel.ConsoleApp.EfPersistence.Users;
using Esmaeel.ConsoleApp.Entities;
using Esmaeel.ConsoleApp.IO.Interfaces;
using Library.Ef.ConsoleApp.Exceptions;

namespace Esmaeel.ConsoleApp.IO.Menus;

public class UserMenu(EfDataContext dbContext, IUi ui) : MenuStructure(ui)
{
    private readonly EfUserRepository _efUserRepository =
        new EfUserRepository(dbContext);

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
        var newUser = new User
        {
            Name = ui.GetStringFromUser("Enter User Name :"),
        };
        _efUserRepository.Create(newUser);
        dbContext.SaveChanges();
    }

    private void ShowAll()
    {
        var users = _efUserRepository.GetAll();
        users.ForEach(_ => { ui.ShowMessage($"Id: {_.Id}, Name: {_.Name}"); });
    }

    private void Edit()
    {
        ShowAll();
        int userId = ui.GetIntegerFromUser("Enter User Id :");
        var user = _efUserRepository.GetById(userId)
            ?? throw new Exception("User does not exist");
        user.Name = ui.GetStringFromUser("Enter User Name :");
        dbContext.SaveChanges();
    }

    private void Delete()
    {
        ShowAll();
        int userId = ui.GetIntegerFromUser("Enter User Id :");
        var user = _efUserRepository.GetById(userId)
                   ?? throw new Exception("User does not exist");
        _efUserRepository.Delete(user);
        dbContext.SaveChanges();
    }
}