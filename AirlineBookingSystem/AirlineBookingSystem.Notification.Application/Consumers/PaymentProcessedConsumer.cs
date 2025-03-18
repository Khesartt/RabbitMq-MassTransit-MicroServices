namespace AirlineBookingSystem.Notification.Application.Consumers;

using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;
using AirlineBookingSystem.Notification.Application.Commands;
using AirlineBookingSystem.Notification.Domain.Entities.Enums;
using MassTransit;
using MediatR;

public class PaymentProcessedConsumer(IMediator mediator) : IConsumer<PaymentProcessedEvent>
{
    private readonly IMediator mediator = mediator;

    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var Message = $"Payment of ${paymentProcessedEvent.Amount} has been processed for booking {paymentProcessedEvent.BookingId}";
        await this.mediator.Send(new SendNotificationCommand("pepito@empresasPepito.com", Message, NotificationType.email));
    }
}