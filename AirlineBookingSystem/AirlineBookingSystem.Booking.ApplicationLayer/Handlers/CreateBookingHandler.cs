namespace AirlineBookingSystem.Booking.Application.Handlers;

using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Domain.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;
using MediatR;

public class CreateBookingHandler(IBookingRepository bookingRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<CreateBookingCommand, Guid>
{
    private readonly IBookingRepository bookingRepository = bookingRepository;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

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

        //publish event

        await this.publishEndpoint.Publish(new FlightBookedEvent(booking.Id,
                                                                 booking.FlightId,
                                                                 booking.PassengerName,
                                                                 booking.SeatNumber,
                                                                 booking.BookingDate));


        return booking.Id;
    }
}