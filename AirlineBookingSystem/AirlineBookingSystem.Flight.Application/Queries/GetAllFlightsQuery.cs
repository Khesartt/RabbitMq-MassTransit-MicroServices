using MediatR;

namespace AirlineBookingSystem.Flight.Application.Queries;

public record GetAllFlightsQuery : IRequest<IEnumerable<Domain.Entities.Flight>>;
