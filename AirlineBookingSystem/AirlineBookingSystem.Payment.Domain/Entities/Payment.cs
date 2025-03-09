namespace AirlineBookingSystem.Payment.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public string? BookingId { get; set; }

    public DateTime PaymentDate { get; set; }
}