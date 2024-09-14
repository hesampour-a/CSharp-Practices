using Shop.ConsoleApp.Ef.EfPersistances;
using Shop.ConsoleApp.Ef.IO;
using Shop.ConsoleApp.Ef.IO.Menus;

var dbContext = new EfDataContext();
var ui = new ConsoleUi();

var mainMenu = new MainMenu(dbContext,ui);
mainMenu.Show();