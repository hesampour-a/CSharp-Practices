using Tickets.ConsoleApp.IOs;
using Tickets.ConsoleApp.Menus;
using Tickets.Models.Models.TicketsSystem;

var io = new ConsoleUi();
var ticketSystem = new TicketSystem();
var mainMenui = new MainMenu(ticketSystem,io);
mainMenui.Show();