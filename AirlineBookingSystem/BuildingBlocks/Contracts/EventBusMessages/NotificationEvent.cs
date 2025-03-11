namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;

public record NotificationEvent(string Recipient, string message, string type);