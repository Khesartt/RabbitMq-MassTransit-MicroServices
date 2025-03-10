namespace AirlineBookingSystem.Flight.Domain.Entities;

public class Flight
{
    public Guid Id { get; set; }

    public string? FlightNumber { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateTime ArrivalDate { get; set; }

    public DateTime DepartureDate { get; set; }
}