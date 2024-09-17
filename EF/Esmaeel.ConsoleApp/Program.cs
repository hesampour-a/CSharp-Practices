using Esmaeel.ConsoleApp.EfPersistence;
using Esmaeel.ConsoleApp.IO;
using Esmaeel.ConsoleApp.IO.Menus;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();