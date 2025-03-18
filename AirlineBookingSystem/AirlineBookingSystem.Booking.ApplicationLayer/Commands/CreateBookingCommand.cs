namespace AirlineBookingSystem.Booking.Application.Commands;

using MediatR;

public record CreateBookingCommand(Guid FlightId, string PassengerName, string SeatNumber) : IRequest<Guid>;