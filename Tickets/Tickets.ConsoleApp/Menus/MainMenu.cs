
using Tickets.ConsoleApp.Interfaces;
using Tickets.Models.Models.TicketsSystem;
using Tickets.Models.Models.TicketsSystem.Contracts.DTOs;

namespace Tickets.ConsoleApp.Menus;
internal class MainMenu(TicketSystem ticketSystem, IConsoleUi io)
{
    
    void ShowMenu()
    {
       io.Show("1. Add Customer");
       io.Show("2. Add City");
       io.Show("3. Add Bus");
       io.Show("4. Add Trip");
       io.Show("5. Sell Ticket");
       io.Show("6. Cancel Ticket");
       io.Show("7. Show bus functionality");
       io.Show("8. show city with most input");
       io.Show("9. show city with most output");
       io.Show("0. Exit");
    }

    void CreateCustomer()
    {

        var newCustomer = ticketSystem.RegisterCustomer(new CreateCustomerDto
        {
            Name = io.GetString("Enter Name :"),
            NationalCode = io.GetString("Enter National Code :"),
            PhoneNumber = io.GetString("Enter Phone Number :"),
        });
       io.Show($"your ID : {newCustomer.Id}");
    }

    void CreateCity()
    {
        var newCity = ticketSystem.RegisterCity(new CreateCityDto
        {
            Name = io.GetString("Enter City Name:")
        });
       io.Show($"City ID : {newCity.Id}");
    }
    void CreateBus()
    {
        var newBus = ticketSystem.RegisterBus(new CreateBusDto
        {
            Type = io.GetInt("Enter Bus Type 1.Regular 2.VIP :"),
            Capacity = io.GetInt("Enter Capacity :"),
            LicensePlate = io.GetString("Enter LicensePlate :")
        });
       io.Show($"Bus ID : {newBus.Id}");
    }

    void CreteTrip()
    {
        var newTrip = ticketSystem.RegisterTrip(new CreateTripDto
        {
            BusId = io.GetInt("Enter Bus ID :"),
            Date = io.GetDate("Enter Date"),
            OriginCityId = io.GetInt("Enter OriginCity ID"),
            DestinationCityId = io.GetInt("Enter DestinationCityId"),
            TicketPrice = io.GetDouble("Enter Ticket Price")
        });
       io.Show($"Trip ID : {newTrip.Id}");
    }
    void SellTicket()
    {
        var avalibleTrips = ticketSystem.ShowAvalibleTrips();

        avalibleTrips.ForEach(_ =>
        {
            Console.WriteLine($"Id : {_.Id +1} , OriginCity : {_.OriginCity} , DestinationCity : {_.DestinationCity} , BusType : {_.BusType} , Date : {_.Date} , Price : {_.TicketPrice}");
        });

        var tripId = io.GetInt("Enter Trip ID :");
        var ticketType = io.GetInt("you want to 1.Buy or 2.Reserve");

        string priceToPay = (ticketType == 1 ? $"pay {avalibleTrips[tripId - 1].TicketPrice}" : $"pay {avalibleTrips[tripId - 1].TicketPrice * 30 / 100}");
       io.Show(priceToPay);
       var newTicket =  ticketSystem.RegisterTicket(new CreateTicketDto
        {
            CustomerId = io.GetInt("Enter your ID :"),
            TripId = tripId,
            TicketType = ticketType

        });
       io.Show($"Ticket ID : {newTicket.Id}");
       io.Show($"Trip ID : {newTicket.TripId}");
    }

    void ShowBusFunctionaltity()
    {
        var dtos = ticketSystem.BusFunctionality();
        dtos.ForEach(_ => {
            Console.WriteLine($"{_.LicensePlate} , {_.TotalSell}");
        });
    }
    void ShowCityWithMostIn()
    {
       var dto =  ticketSystem.CityWithMostInput();
       io.Show($"City {dto.Name} With {dto.PassengerCount} Passengers");
    }
    void ShowCityWithMostOut()
    {
        var dto = ticketSystem.CityWithMostOutput();
       io.Show($"City {dto.Name} With {dto.PassengerCount} Passengers");
    }
    void CancelTicket()
    {
        var ticketId = io.GetInt("Enter Ticket ID :");
        var tripId = io.GetInt("Enter Trip ID :");
        var ticket = ticketSystem.GetTicketById(tripId, ticketId);
       io.Show($"get {ticket.CancelPrice}");
        ticketSystem.CancelTicket(new CancelTicketDto
        {
            TicketId = ticketId,
            TripId = tripId

        });
    }

    public void Show()
    {
       io.Show(DateTime.Now.ToString());
        while (true)
        {
            ShowMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    CreateCustomer();
                    break;
                case "2":
                    CreateCity();
                    break;
                case "3":
                    CreateBus();
                    break;
                case "4":
                    CreteTrip();
                    break;
                case "5":
                    SellTicket();
                    break;
                case "6":
                    CancelTicket();
                    break;
                case "7":
                    ShowBusFunctionaltity();
                    break;
                case "8":
                    ShowCityWithMostIn();
                    break;
                    case "9":
                    ShowCityWithMostOut();
                    break;
                case "0":
                    return;
            }
            
            io.GetString("Press Any Key To Continue ...");
            io.Clear();

        }
    }
}
