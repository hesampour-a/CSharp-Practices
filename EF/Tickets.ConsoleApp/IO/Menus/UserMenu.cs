using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.EfPersistence.Users;
using Tickets.ConsoleApp.Entities;
using Tickets.ConsoleApp.Exceptions;
using Tickets.ConsoleApp.IO.Interfaces;

namespace Tickets.ConsoleApp.IO.Menus;

public class UserMenu(EfDataContext dbContext, IUi ui)
    : MenuStructure(dbContext, ui)
{
    private readonly EfUserRepository _userRepository =
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
            FirstName = ui.GetStringFromUser("Enter first name"),
            LastName = ui.GetStringFromUser("Enter last name"),
            NationalCode = ui.GetStringFromUser("Enter national code"),
            PhoneNumber = ui.GetStringFromUser("Enter phone number"),
        };
        _userRepository.Create(newUser);
        dbContext.SaveChanges();
        ui.ShowMessage($"ID: {newUser.Id}");
    }

    public void ShowAll()
    {
        var users = _userRepository.GetAll();
        users.ForEach(_ =>
        {
            ui.ShowMessage(
                $"ID: {_.Id}, First Name: {_.FirstName}, Last Name: {_.LastName}, National Code: {_.NationalCode}, Phone Number: {_.PhoneNumber}");
        });
    }

    private void Edit()
    {
        ShowAll();
        var userId = ui.GetIntegerFromUser("Enter user ID:");
        var user = _userRepository.GetById(userId)
                   ?? throw new NotFoundException(nameof(User), userId);
        user.FirstName = ui.GetStringFromUser("Enter new first name");
        user.LastName = ui.GetStringFromUser("Enter new last name");
        user.NationalCode = ui.GetStringFromUser("Enter new national code");
        user.PhoneNumber = ui.GetStringFromUser("Enter new phone number");
        dbContext.SaveChanges();
        
    }

    private void Delete()
    {
        ShowAll();
        var userId = ui.GetIntegerFromUser("Enter user ID:");
        var user = _userRepository.GetById(userId)
                   ?? throw new NotFoundException(nameof(User), userId);
        _userRepository.Delete(user);
        dbContext.SaveChanges();
    }
}