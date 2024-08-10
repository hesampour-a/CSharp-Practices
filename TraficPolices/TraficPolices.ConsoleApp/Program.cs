using Models.TraficPolices;
using TraficPolices.ConsoleApp.Menus;

var traficPolice = new TraficPolice();

var mainMenu = new MainMenu(traficPolice);
mainMenu.Show();