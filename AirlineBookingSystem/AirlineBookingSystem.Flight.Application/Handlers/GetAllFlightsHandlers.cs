namespace AirlineBookingSystem.Flight.Application.Handlers;

using AirlineBookingSystem.Flight.Application.Queries;
using AirlineBookingSystem.Flight.Domain.Repositories;
using MediatR;

public class GetAllFlightsHandlers(IFlightRepository flightRepository) : IRequestHandler<GetAllFlightsQuery, IEnumerable<Domain.Entities.Flight>>
{
    private readonly IFlightRepository flightRepository = flightRepository;

    public async Task<IEnumerable<Domain.Entities.Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await this.flightRepository.GetFlightsAsync();
    }
}