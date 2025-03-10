namespace AirlineBookingSystem.Notification.Application.Commands;

using AirlineBookingSystem.Notification.Domain.Entities.Enums;
using MediatR;

public record SendNotificationCommand(string Recipient, string Message, NotificationType Type) : IRequest;