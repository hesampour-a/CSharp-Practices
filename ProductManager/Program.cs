using ProductManager.Models;
using ProductManager.Ui;

var shop = new Shop();
var menu = new MainMenu(shop);
menu.Start();