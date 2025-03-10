namespace AirlineBookingSystem.Flight.Application.Commands;

using MediatR;

public record CreateFlightCommand(string FlightNumber,
                                  string Origin,
                                  string Destination,
                                  DateTime DepartureTime,
                                  DateTime ArrivalTime) : IRequest<Guid>;