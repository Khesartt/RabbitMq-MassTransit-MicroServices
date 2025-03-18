namespace AirlineBookingSystem.Notification.Domain.Repositories;

using AirlineBookingSystem.Notification.Domain.Entities;

public interface INotificationRepository
{
    Task LogNotificationAsync(Notification notification);
}