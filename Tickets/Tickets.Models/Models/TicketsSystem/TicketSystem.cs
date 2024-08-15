using Tickets.Models.Enums;
using Tickets.Models.Models.Buses;
using Tickets.Models.Models.Tickets;
using Tickets.Models.Models.TicketsSystem.Contracts.DTOs;
using Tickets.Models.Models.Trips;
using Tickets.Models.Models.Users;

namespace Tickets.Models.Models.TicketsSystem;

public class TicketSystem
{
    private readonly List<Trip> _trips = [];
    private readonly List<Bus> _buses = [];
    private readonly List<Customer> _customers = [];
    private readonly List<City> _cities = [];


    public ShowCustomerDto RegisterCustomer(CreateCustomerDto dto)
    {
        _customers.Add(new Customer(dto.PhoneNumber, dto.Name, dto.NationalCode));
        return new ShowCustomerDto
        {
            Id = _customers.Count,
        };
    }
    public ShowBusDto RegisterBus(CreateBusDto dto)
    {
        _buses.Add(new Bus(dto.LicensePlate, (BusType)dto.Type, dto.Capacity));
        return new ShowBusDto
        {
            Id = _buses.Count,
        };
    }
    public ShowTripDto RegisterTrip(CreateTripDto dto)
    {
        var bus = _buses[dto.BusId - 1];
        var newTrip = new Trip(bus, dto.TicketPrice, _cities[dto.OriginCityId - 1], _cities[dto.DestinationCityId - 1], dto.Date);
        _trips.Add(newTrip);

        return new ShowTripDto
        {
            Id = _trips.Count,

        };

    }
    public ShowCityDto RegisterCity(CreateCityDto dto)
    {
        _cities.Add(new City(dto.Name));
        return new ShowCityDto { Id = _cities.Count() };
    }
    public ShowTicketDto RegisterTicket(CreateTicketDto dto)
    {
        var customer = _customers[dto.CustomerId - 1];
        var trip = _trips[dto.TripId - 1];
        var ticketType = (TicketType)dto.TicketType;

        if (IsTripStarted(trip))
            throw new Exception("this trip is started!");
        if (CalculateRemainingCapacityForTrip(dto.TripId) == 0)
            throw new Exception("this trip capacity is full");

        var newTicket = new Ticket(customer, trip, ticketType);
        trip.SoldTickets.Add(newTicket);

        return new ShowTicketDto
        {
            Id = trip.SoldTickets.Count,
            TripId = dto.TripId
        };

    }
    int CalculateRemainingCapacityForTrip(int tripId)
    {
        var trip = _trips[tripId - 1];
        return trip.Bus.Capacity - trip.SoldTickets.Count();
    }
    bool IsTripStarted(Trip trip) => DateTime.Now >= trip.Date;

    public List<ShowBusFunctionalityDto> BusFunctionality()
    {
        List<ShowBusFunctionalityDto> busFunctionalityDtos = [];
        foreach (var bus in _buses)
        {
            double totlaPrice = 0;
            foreach (var trip in _trips)
            {
                if (bus == trip.Bus)
                    totlaPrice += trip.SoldTickets.Count() * trip.TicketPrice;
            }
            busFunctionalityDtos.Add(new ShowBusFunctionalityDto
            {
                LicensePlate = bus.LicensePlate,
                TotalSell = totlaPrice,
            });

        }
        return busFunctionalityDtos.OrderByDescending(_ => _.TotalSell).ToList();
    }

    public CityFunctionalityDto CityWithMostInput()
    {

        return _trips.GroupBy(_ => _.DestinationCity).Select(_ => new
        {
            City = _.Key,
            PassengersCount = _.Sum(t => t.SoldTickets.Count())

        }).Select(_ => new CityFunctionalityDto
        {
            Name = _.City.Name,
            PassengerCount = _.PassengersCount
        }).OrderByDescending(_ => _.PassengerCount).First();

        //List<CityFunctionalityDto> cityFunctionalityDtos = [];
        //foreach (var city in _cities)
        //{
        //    int inPassengerCount = 0;
        //    //GroupBy
        //    foreach (var trip in _trips)
        //    {
        //        if (trip.DestinationCity == city)
        //            inPassengerCount += trip.SoldTickets.Count();
        //    }
        //    cityFunctionalityDtos.Add(new CityFunctionalityDto
        //    {
        //        Name = city.Name,
        //        PassengerCount = inPassengerCount,
        //    });

        //}

        //return cityFunctionalityDtos.OrderByDescending(_ => _.PassengerCount).ToList().First();
    }

    public CityFunctionalityDto CityWithMostOutput()
    {
        return _trips.GroupBy(_ => _.OriginCity).Select(_ => new
        {
            City = _.Key,
            PassengersCount = _.Sum(t => t.SoldTickets.Count())

        }).Select(_ => new CityFunctionalityDto
        {
            Name = _.City.Name,
            PassengerCount = _.PassengersCount
        }).OrderByDescending(_ => _.PassengerCount).First();
        //List<CityFunctionalityDto> cityFunctionalityDtos = [];
        //foreach (var city in _cities)
        //{
        //    int outPassengerCount = 0;

        //    foreach (var trip in _trips)
        //    {
        //        if (trip.OriginCity == city)
        //            outPassengerCount += trip.SoldTickets.Count();
        //    }
        //    cityFunctionalityDtos.Add(new CityFunctionalityDto
        //    {
        //        Name = city.Name,
        //        PassengerCount = outPassengerCount,
        //    });

        //}

        //return cityFunctionalityDtos.OrderByDescending(_ => _.PassengerCount).ToList().First();
    }

    public List<ShowTripDto> ShowAvalibleTrips()
    {
        var avalibleTrips = _trips.Where(_ => _.Date > DateTime.Now && _.Bus.Capacity - _.SoldTickets.Count > 0).ToList();
        return avalibleTrips.Select(_ => new ShowTripDto
        {
            BusType = Enum.GetName(typeof(BusType), _.Bus.Type)!,
            Date = _.Date.ToString(),
            OriginCity = _.OriginCity.Name,
            DestinationCity = _.DestinationCity.Name,
            RemainingCapacity = _.Bus.Capacity - _.SoldTickets.Count(),
            TicketPrice = _.TicketPrice
        }).ToList();
    }

    public void CancelTicket(CancelTicketDto dto)
    {
        _trips[dto.TripId - 1].SoldTickets.RemoveAt(dto.TripId - 1);
    }

    public ShowTicketDto GetTicketById(int tripId, int ticketId)
    {
        var ticket = _trips[tripId - 1].SoldTickets[ticketId - 1];


        return new ShowTicketDto
        {
            Id = ticketId,
            TripId = tripId,

            CancelPrice = ticket.Type == TicketType.Cash ? (0.80 * _trips[tripId - 1].TicketPrice) : 0
        };

    }


}
