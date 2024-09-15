using Library.Ef.ConsoleApp.IO.Interfaces;

namespace Library.Ef.ConsoleApp.IO.Menus;

public class BookMenu(IUi ui) : MenuStructure(ui)
{
    protected override string ExitMessageMenu { get; } = "Back to Main Menu";

    protected override void AddMenuItems()
    {
        MenuItems.Add("Create new Book",CreateBook);
        MenuItems.Add("See All Books",ShowAllBooks);
        MenuItems.Add("Edit Book",EditBook);
        MenuItems.Add("Delete Book",DeleteBook);
    }

    private void EditBook()
    {
        throw new NotImplementedException();
    }

    private void DeleteBook()
    {
        throw new NotImplementedException();
    }

    private void ShowAllBooks()
    {
        throw new NotImplementedException();
    }

    private void CreateBook()
    {
        throw new NotImplementedException();
    }

   
}