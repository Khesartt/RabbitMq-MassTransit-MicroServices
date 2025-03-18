namespace AirlineBookingSystem.Flight.Domain.Repositories;

using AirlineBookingSystem.Flight.Domain.Entities;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetFlightsAsync();

    Task AddFlightAsync(Flight flight);

    Task DeleteFlightAsync(Guid id);
}