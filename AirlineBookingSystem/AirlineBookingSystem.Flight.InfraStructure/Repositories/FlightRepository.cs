namespace AirlineBookingSystem.Flight.InfraStructure.Repositories;

using AirlineBookingSystem.Flight.Domain.Repositories;
using AirlineBookingSystem.Flight.InfraStructure.Persistances.SqlServer;
using Microsoft.EntityFrameworkCore;

public class FlightRepository(ApiContext context) : IFlightRepository
{
    private readonly ApiContext _context = context;

    public async Task AddFlightAsync(Domain.Entities.Flight flight)
    {
        _context.Flights.Add(flight);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFlightAsync(Guid id)
    {
        var flight = await _context.Flights.FindAsync(id);
        if (flight != null)
        {
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Domain.Entities.Flight>> GetFlightsAsync()
    {
        return await _context.Flights.ToListAsync();
    }
}