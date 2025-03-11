namespace AirlineBookingSystem.Flight.Application.Handlers;

using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Domain.Repositories;
using MediatR;

public class CreateFlightHandler(IFlightRepository flightRepository) : IRequestHandler<CreateFlightCommand, Guid>
{
    private readonly IFlightRepository flightRepository = flightRepository;

    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Domain.Entities.Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureTime  = request.DepartureTime,
            ArrivalTime = request.ArrivalTime
        };

        await this.flightRepository.AddFlightAsync(flight);

        return flight.Id;
    }
}