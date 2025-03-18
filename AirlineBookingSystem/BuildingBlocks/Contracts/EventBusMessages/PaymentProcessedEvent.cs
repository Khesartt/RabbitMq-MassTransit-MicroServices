namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;

public record PaymentProcessedEvent(Guid PaymentId, Guid BookingId, decimal Amount, DateTime PaymentDate);