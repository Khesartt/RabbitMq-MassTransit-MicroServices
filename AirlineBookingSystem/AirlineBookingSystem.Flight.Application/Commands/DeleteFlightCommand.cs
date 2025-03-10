namespace AirlineBookingSystem.Flight.Application.Commands;

using MediatR;

public record DeleteFlightCommand(Guid Id) : IRequest;