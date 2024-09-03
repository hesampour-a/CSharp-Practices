using S4.Data;
using S4.Models;

var dbContext = new EfDataContext();

//CreateCountries(dbContext);
//CreateStates(dbContext);
//CreateCities(dbContext);

var countries = dbContext.Countries.ToList();
Console.WriteLine($"Total countries: {countries.Count}");

var states = dbContext.States.ToList();
Console.WriteLine($"Total states: {states.Count}");

var cities = dbContext.Cities.ToList();
Console.WriteLine($"Total cities: {cities.Count}");

var toBeDeletedCity = dbContext.Cities.FirstOrDefault(_ => _.Title == "City 7");
dbContext.Cities.Remove(toBeDeletedCity);
dbContext.SaveChanges();

var toBeUpdatedCity = dbContext.Cities.FirstOrDefault(_=>_.Title == "City 6");
toBeUpdatedCity.Title = "City 66";
dbContext.SaveChanges();



void CreateCountries(EfDataContext dbContext)
{
    List<Country> countries =
    [
        new Country
        {
            Title = "USA"
        },
        new Country
        {
            Title = "Canada"
        },
        new Country
        {
        Title = "Italy"
        },
        new Country
        {
            Title = "Germany"
        }
    ];
    
    dbContext.Countries.AddRange(countries);
    dbContext.SaveChanges();
}

void CreateStates(EfDataContext dbContext)
{
    List<State> states =
    [
        new State
        {
            Title = "Arizona",
            CountryId = 1
        },
        new State
        {
            Title = "Virginia",
            CountryId = 1
        },
        new State
        {
            Title = "FirstCanadaState",
            CountryId = 2
        }, 
        new State
        {
            Title = "SecondCanadaState",
            CountryId = 2
        },
        new State
        {
            Title = "FirstItalyState",
            CountryId = 3
        },
        new State
        {
            Title = "FirstGermanyState",
            CountryId = 4
        },
    ];
    
    dbContext.States.AddRange(states);
    dbContext.SaveChanges();
}

void CreateCities(EfDataContext dbContext)
{
    List<City> cities = [
        new City
        {
            Title = "City 1",
            StateId = 1
        },
        new City
        {
            Title = "City 2",
            StateId = 1
        },
        new City
        {
            Title = "City 3",
            StateId = 2
        },
        new City
        {
            Title = "City 4",
            StateId = 3
        },
        new City
        {
            Title = "City 5",
            StateId = 4
        },
        new City
        {
            Title = "City 6",
            StateId = 5
        },
        new City
        {
            Title = "City 7",
            StateId = 6
        },
    ];
    dbContext.Cities.AddRange(cities);
    dbContext.SaveChanges();
}