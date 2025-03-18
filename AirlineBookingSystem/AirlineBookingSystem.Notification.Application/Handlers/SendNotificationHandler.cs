namespace AirlineBookingSystem.Notification.Application.Handlers;

using AirlineBookingSystem.Notification.Application.Commands;
using AirlineBookingSystem.Notification.Application.Interfaces;
using MediatR;

public class SendNotificationHandler(INotificationService notificationService) : IRequestHandler<SendNotificationCommand>
{
    private readonly INotificationService notificationService = notificationService;

    public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Domain.Entities.Notification
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type
        };

        await this.notificationService.SendNotificationAsync(notification);
    }
}