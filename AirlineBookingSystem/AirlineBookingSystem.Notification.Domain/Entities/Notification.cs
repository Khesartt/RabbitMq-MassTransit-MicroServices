namespace AirlineBookingSystem.Notification.Domain.Entities;

using AirlineBookingSystem.Notification.Domain.Entities.Enums;

public class Notification
{
    public Guid Id { get; set; }

    public string? Recipient { get; set; }

    public string? Message { get; set; }

    public NotificationType Type { get; set; }
}