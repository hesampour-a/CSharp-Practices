using BuildingManagement.ConsoleApp.EfPersistence;
using BuildingManagement.ConsoleApp.IO;
using BuildingManagement.ConsoleApp.IO.Menus;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();

var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();