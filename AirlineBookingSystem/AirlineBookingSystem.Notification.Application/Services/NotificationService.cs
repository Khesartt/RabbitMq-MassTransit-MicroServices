namespace AirlineBookingSystem.Notification.Application.Services;

using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;
using AirlineBookingSystem.Notification.Application.Interfaces;
using MassTransit;

public class NotificationService(IPublishEndpoint publishEndpoint) : INotificationService
{
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

    public async Task SendNotificationAsync(Domain.Entities.Notification notification)
    {
        Console.WriteLine("datos enviandos");

        //publish notification
        var notificationEvent = new NotificationEvent(notification?.Recipient ?? string.Empty,
                                                      notification?.Message ?? string.Empty,
                                                      notification?.Type.ToString() ?? string.Empty);

        await this.publishEndpoint.Publish(notificationEvent);
    }
}