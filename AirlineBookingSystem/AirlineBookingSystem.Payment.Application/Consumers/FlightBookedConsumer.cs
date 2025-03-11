using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;
using AirlineBookingSystem.Payments.Application.Commands;
using MassTransit;
using MassTransit.Mediator;

namespace AirlineBookingSystem.Payment.Application.Consumers;

public class FlightBookedConsumer(IMediator mediator) : IConsumer<FlightBookedEvent>
{
    private readonly IMediator mediator = mediator;

    public async Task Consume(ConsumeContext<FlightBookedEvent> context)
    {
        var flightBookedEvent = context.Message;

        var command = new ProcessPaymentCommand(flightBookedEvent.BookingId, 200.00m);

        await this.mediator.Send(command);
    }
}