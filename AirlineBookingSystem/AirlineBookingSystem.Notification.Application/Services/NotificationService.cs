namespace AirlineBookingSystem.Notification.Application.Services;

using AirlineBookingSystem.Notification.Application.Interfaces;

public class NotificationService : INotificationService
{
    public Task SendNotificationAsync(Domain.Entities.Notification notification)
    {
        Console.WriteLine("datos enviandos");

        return Task.CompletedTask;
    }
}