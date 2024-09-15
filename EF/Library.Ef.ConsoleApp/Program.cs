using Library.Ef.ConsoleApp.EfPersistence;
using Library.Ef.ConsoleApp.IO;
using Library.Ef.ConsoleApp.IO.Menus;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();
