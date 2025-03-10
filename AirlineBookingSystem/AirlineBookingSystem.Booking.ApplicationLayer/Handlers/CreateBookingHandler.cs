namespace AirlineBookingSystem.Booking.Application.Handlers;

using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Domain.Repositories;
using MediatR;

public class CreateBookingHandler(IBookingRepository bookingRepository) : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository bookingRepository = bookingRepository;

    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Domain.Entities.Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.Now
        };

        await this.bookingRepository.AddBookingAsync(booking);

        return booking.Id;
    }
}