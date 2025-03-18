namespace AirlineBookingSystem.Booking.Application.Queries;

using MediatR;

public record GetBookingQuery(Guid Id): IRequest<Domain.Entities.Booking>;