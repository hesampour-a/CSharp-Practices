using Microsoft.EntityFrameworkCore;
using Tickets.ConsoleApp.Constants;
using Tickets.ConsoleApp.Dtos.Trips;
using Tickets.ConsoleApp.Entities;

namespace Tickets.ConsoleApp.EfPersistence.Trips;

public class EfTripRepository(EfDataContext dbContext)
{
    public int Create(Trip newTrip)
    {
        dbContext.Trips.Add(newTrip);
        return newTrip.Id;
    }

    public List<ShowTripDto> GetAllAvailable()
    {
        return dbContext.Trips.Include(_ => _.Tickets).Include(_ => _.Bus)
            .Where(_ =>
                _.Date >= DateTime.Now && (_.Tickets.Count() < (_.Bus.BusType ==
                    BusType.Economy
                        ? BusConstants.EconomyTypeCapacity
                        : BusConstants.VipTypeCapacity))).Select(_ =>
                new ShowTripDto
                {
                    Id = _.Id,
                    BusId = _.BusId,
                    Date = _.Date,
                    OriginCity = _.OriginCity,
                    DestinationCity = _.DestinationCity,
                    PricePerTicket = _.PricePerTicket,
                }).ToList();
    }

    public Trip? GetById(int tripId)
    {
        return dbContext.Trips.FirstOrDefault(_ => _.Id == tripId);
    }

    public void Delete(Trip trip)
    {
        dbContext.Trips.Remove(trip);
    }

    public List<ShowCityReportDto> GetCityInputReport()
    {
        return dbContext.Trips.GroupBy(_ => _.OriginCity).Select(_ =>
            new ShowCityReportDto
            {
                Name = _.Key,
                Count = _.Count(),
            }).OrderByDescending(_ => _.Count).ToList();
    }

    public List<ShowCityReportDto> GetCityOutputReport()
    {
        return dbContext.Trips.GroupBy(_ => _.DestinationCity).Select(_ =>
            new ShowCityReportDto
            {
                Name = _.Key,
                Count = _.Count(),
            }).OrderByDescending(_ => _.Count).ToList();
    }
}