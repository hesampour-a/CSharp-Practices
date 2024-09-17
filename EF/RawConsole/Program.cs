using Tickets.ConsoleApp.EfPersistence;
using Tickets.ConsoleApp.IO;
using Tickets.ConsoleApp.IO.Menus;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);
mainMenu.Show();