using RentServiceOOP.Interfaces;

namespace RentServiceOOP.Entities;

public class RentService(IUi ui)
{
    public List<House> Houses { get; set; } = [];
    public List<User> Users { get; set; } = [];
    public List<Contract> Contracts { get; set; } = [];
    public List<Income> Incomes { get; set; } = [];

    void AddUser()
    {

        User user = ui.GetUser();
        user.Id = CalculateNewItemId(Users);
        Users.Add(user);
    }
    void AddHouse()
    {
        House house = new();
        do
        {
            house = ui.GetHouse();
        } while (!HouseValidator(house));
        house.Id = CalculateNewItemId(Houses);
        Houses.Add(house);
    }
    void AddContract(Contract contract)
    {
        contract.Id = CalculateNewItemId(Contracts);
        Contracts.Add(contract);
    }
    int CalculateNewItemId<T>(List<T> list) where T : HasIdClass
    {
        return list.Count > 0 ? list.Last().Id + 1 : 1;
    }

    public static bool HouseValidator(House house) => house.RentRate >= 2000000 && house.MortgageRate >= 30000000;

    bool ContractValidator(Contract contract)
    {
        bool isValid = false;
        var house = Houses.FindLast(h => h.Id == contract.HouseId);
        var contract = Contracts.FindLast(c => c.HouseId == contract.HouseId);

        return true;
    }
    // bool UserValidator => true;

    // public List<T> AddItem<T>(List<T> items, Func<T, bool>? validator, Func<T> getItemFromUser) where T : HasIdClass
    // {
    //     bool isItemValid = false;
    //     do
    //     {
    //         T item = getItemFromUser();
    //         item.Id = CalculateNewItemId(items);
    //         isItemValid = validator == null ? true : validator(item);
    //         if (isItemValid)
    //             items.Add(item);
    //     } while (!isItemValid);
    //     return items;
    // }

}