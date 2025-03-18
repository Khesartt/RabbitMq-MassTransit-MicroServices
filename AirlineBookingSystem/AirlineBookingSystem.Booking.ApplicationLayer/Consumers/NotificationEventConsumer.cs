using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;
using MassTransit;

namespace AirlineBookingSystem.Booking.Application.Consumers;

public class NotificationEventConsumer:IConsumer<NotificationEvent>
{
    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        var notification = context.Message;
        Console.WriteLine($"Notification sent to {notification.Recipient} with message {notification.message} of type {notification.type}");
    
        await Task.CompletedTask;
    }
}