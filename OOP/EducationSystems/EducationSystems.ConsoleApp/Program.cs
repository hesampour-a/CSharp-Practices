using EducationSystems.ConsoleApp.Menus;
using EducationSystems.Models.Models.EducationSystems;

var educationSystem = new EducationSystem();

var menu = new MainMenu(educationSystem);
menu.Show();