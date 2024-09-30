using Models.TraficPolices;
using TraficPolices.ConsoleApp.Interfaces;
using TraficPolices.ConsoleApp.Menus;
using TraficPolices.ConsoleApp.Uis;

var traficPolice = new TraficPolice();

IUi ui = new ConsoleUi();

var mainMenu = new MainMenu(traficPolice,ui);
mainMenu.Show();