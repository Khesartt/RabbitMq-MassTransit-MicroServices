namespace AirlineBookingSystem.Flight.Application.Handlers;

using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Domain.Repositories;
using MediatR;

public class DeleteFlightHandler(IFlightRepository flightRepository) : IRequestHandler<DeleteFlightCommand>
{
    private readonly IFlightRepository flightRepository = flightRepository;

    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await this.flightRepository.DeleteFlightAsync(request.Id);
    }
}