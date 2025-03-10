namespace AirlineBookingSystem.Notification.Application.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Domain.Entities.Notification notification);
}