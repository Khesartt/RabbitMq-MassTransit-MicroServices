namespace AirlineBookingSystem.Notification.InfraStructure.Repositories;

using AirlineBookingSystem.Notification.Domain.Repositories;
using AirlineBookingSystem.Notification.InfraStructure.Persistances.SqlServer;

public class NotificationRepository(ApiContext context) : INotificationRepository
{
    private readonly ApiContext _context = context;

    public async Task LogNotificationAsync(Domain.Entities.Notification notification)
    {
        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();
    }
}