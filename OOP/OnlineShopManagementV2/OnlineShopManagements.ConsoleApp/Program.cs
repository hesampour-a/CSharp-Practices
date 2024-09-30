using OnlineShopManagements.ConsoleApp.Menus;
using OnlineShopManagements.ConsoleApp.UIs;
using OnlineShppManagements.Models.Models.OnlineShopManagements;

var shop = new OnlineShopManagement();
var ui =new ConsoleUi();
new MainMenu(shop,ui).Show();