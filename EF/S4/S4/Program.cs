using S4.Data;
using S4.IOs;
using S4.IOs.Menus;
using S4.Models;

var consoleUi = new ConsoleUi();
var dbContext = new EfDataContext();
var mainMenu = new MainMenu(dbContext, consoleUi);


var fars = dbContext.Provinces.FirstOrDefault(_ => _.Title == "Fars");
var tehran = dbContext.Provinces.FirstOrDefault(_ => _.Title == "Tehran");       


//CreateCountries(dbContext);
//CreateProvinces(dbContext);
//CreateCities(dbContext);

mainMenu.Show();


void CreateCountries(EfDataContext dbContext)
{
    List<Country> countries =
    [
        new Country
        {
            Title = "Iran"
        },
       
    ];
    
    dbContext.Countries.AddRange(countries);
    dbContext.SaveChanges();
}

void CreateProvinces(EfDataContext dbContext)
{
    List<Province> provinces =
    [
        new Province
        {
            Title = "Fars",
            CountryId = 5
        },
        new Province
        {
            Title = "Tehran",
            CountryId = 5
        },
        
    ];
    
    dbContext.Provinces.AddRange(provinces);
    dbContext.SaveChanges();
}

void CreateCities(EfDataContext dbContext)
{
    List<City> cities = [
        new City
        {
            Title = "Shiraz",
            ProvinceId = fars.Id
        },
        new City
        {
            Title = "Zarqan",
            ProvinceId = fars.Id
        },
        new City
        {
            Title = "Tehran",
            ProvinceId = tehran.Id
        },
        new City
        {
            Title = "Damavand",
            ProvinceId = tehran.Id
        },
    ];
    dbContext.Cities.AddRange(cities);
    dbContext.SaveChanges();
}