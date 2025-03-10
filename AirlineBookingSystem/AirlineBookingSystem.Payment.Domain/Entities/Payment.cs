namespace AirlineBookingSystem.Payment.Domain.Entities;

public class Payment
{
    public Guid Id { get; set; }

    public Guid BookingId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }
}