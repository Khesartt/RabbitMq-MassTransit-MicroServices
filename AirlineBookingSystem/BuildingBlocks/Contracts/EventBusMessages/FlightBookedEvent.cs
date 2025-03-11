namespace AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;

public record FlightBookedEvent(Guid BookingId,
                                Guid FlightId,
                                string PassengerName,
                                string SeatNumber,
                                DateTime BookingDate);