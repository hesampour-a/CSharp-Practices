using Microsoft.EntityFrameworkCore;
using S4.Data;
using S4.IOs.Interfaces;
using S4.Models;

namespace S4.IOs.Menus;

public class MainMenu(EfDataContext dbContext, IUi ui) : IMenuBuilder
{
    public Dictionary<string, Action> MenuItems { get; set; } = new();

    public void AddMenuItems()
    {
        MenuItems.Add("Show All Countries", ShowAllCountries);
        MenuItems.Add("Show All Provinces", ShowAllProvinces);
        MenuItems.Add("Show All Cities", ShowAllCities);
        MenuItems.Add("Show All Schools For City", ShowAllSchoolsForCity);
        MenuItems.Add("Show All Schools For Province", ShowAllSchoolsForProvince);
        MenuItems.Add("Show All Schools", ShowAllSchools);
        MenuItems.Add("Show School By Id", ShowSchoolById);
        MenuItems.Add("Create School", CreateSchool);
        MenuItems.Add("Edit School", EditSchool);
        MenuItems.Add("Delete School", DeleteSchool);
    }

    void CreateSchool()
    {
        ShowAllCities();

        int cityId = ui.GetIntegerFromUser("Select City ID : ");
        string schoolName = ui.GetStringFromUser("Enter School Name: ");
        var newSchool = new School
        {
            CityId = cityId,
            Title = schoolName
        };
        dbContext.Schools.Add(newSchool);
        dbContext.SaveChanges();
    }

    void DeleteSchool()
    {
        int schoolId = ui.GetIntegerFromUser("Enter School Id :");
        var school = dbContext.Schools.FirstOrDefault(s => s.Id == schoolId);
        if (school == null)
        {
            ui.ShowMessage($"{nameof(School)} with id {schoolId} not found");
            return;
        }

        dbContext.Schools.Remove(school);
        dbContext.SaveChanges();
    }

    void EditSchool()
    {
        int schoolId = ui.GetIntegerFromUser("Enter School Id :");
        string newTitle = ui.GetStringFromUser("Enter School new Title :");
        var school = dbContext.Schools.FirstOrDefault(_ => _.Id == schoolId);
        if (school == null)
        {
            ui.ShowMessage($"{nameof(School)} with id {schoolId} not found");
            return;
        }

        school.Title = newTitle;
        dbContext.SaveChanges();
    }

    void ShowSchoolById()
    {
        int schoolId = ui.GetIntegerFromUser("Enter School Id");
        var school = dbContext.Schools.FirstOrDefault(_ => _.Id == schoolId);
        if (school == null)
        {
            ui.ShowMessage($"{nameof(School)} with id {schoolId} not found");
            return;
        }

        PrintSchool(school);
    }

    void ShowAllSchools()
    {
        var schools = dbContext.Schools.ToList();

        schools.ForEach(school => { PrintSchool(school); });
    }


    void ShowAllSchoolsForProvince()
    {
        ShowAllProvinces();

        int provinceId = ui.GetIntegerFromUser("Insert Province ID :");
        var province = dbContext.Provinces.FirstOrDefault(_ => _.Id == provinceId);
        if (province == null)
        {
            ui.ShowMessage($"{nameof(Province)} with id {provinceId} not found");
            return;
        }

        // var cities = dbContext.Cities.Where(ci => ci.ProvinceId == provinceId)
        //     .Include(_ => _.Schools)
        //     .ToList();
        var schools = (from city in dbContext.Cities
            join school in dbContext.Schools
                on city.Id equals school.CityId
            select new School
            {
                Title = school.Title,
                Id = city.Id,
            }).ToList();
            schools.ForEach(school => { PrintSchool(school); });
        //cities.ForEach(city => { city.Schools.ForEach(school => { PrintSchool(school); }); });
    }

    void ShowAllSchoolsForCity()
    {
        ShowAllCities();
        int cityId = ui.GetIntegerFromUser("Insert City ID :");
        var city = dbContext.Cities.FirstOrDefault(_c => _c.Id == cityId);
        if (city == null)
        {
            ui.ShowMessage($"{nameof(City)} with id {cityId} not found");
            return;
        }

        var schools = dbContext.Schools.Where(_ => _.CityId == cityId).ToList();

        schools.ForEach(school => { PrintSchool(school); });
    }

    void ShowAllCities()
    {
        ShowAllProvinces();
        int provinceId = ui.GetIntegerFromUser("Insert Province ID :");
        var province = dbContext.Provinces.FirstOrDefault(_ => _.Id == provinceId);
        if (province == null)
        {
            ui.ShowMessage($"{nameof(Province)} with id {provinceId} not found");
            return;
        }

        var cities = dbContext.Cities.Where(p => p.ProvinceId == provinceId).ToList();
        cities.ForEach(city => { PrintCity(city); });
    }

    void ShowAllProvinces()
    {
        ShowAllCountries();
        int countryId = ui.GetIntegerFromUser("Insert Country ID :");
        var country = dbContext.Countries.FirstOrDefault(_ => _.Id == countryId);
        if (country == null)
        {
            ui.ShowMessage($"{nameof(Country)} with id {countryId} not found");
            return;
        }


        var provinces = dbContext.Provinces.Where(p => p.CountryId == countryId).ToList();
        provinces.ForEach(province => { PrintProvince(province); });
    }

    void ShowAllCountries()
    {
        List<Country> countries = dbContext.Countries.ToList();
        countries.ForEach(country => { PrintCountry(country); });
    }

    void PrintCountry(Country country)
    {
        ui.ShowMessage($"Id : {country.Id} , Title : {country.Title}");
    }

    void PrintProvince(Province province)
    {
        ui.ShowMessage($"Id : {province.Id} , Title : {province.Title} , CountryID : {province.CountryId}");
    }

    void PrintCity(City city)
    {
        ui.ShowMessage($"Id : {city.Id} , Title : {city.Title} , ProvinceID : {city.ProvinceId}");
    }

    void PrintSchool(School school)
    {
        ui.ShowMessage($"Id : {school.Id} , Title : {school.Title} , ProvinceID : {school.CityId}");
    }

    public void Show()
    {
        AddMenuItems();
        new MenuBuilder(MenuItems, ui).Start();
    }
}