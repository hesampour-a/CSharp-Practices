using ZooManagement.ConsoleApp.EfPersistence;
using ZooManagement.ConsoleApp.IO;
using ZooManagement.ConsoleApp.IO.Menus;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();