namespace AirlineBookingSystem.Payment.Domain.Repositories;

using AirlineBookingSystem.Payment.Domain.Entities;

public interface IPaymentRepository
{
    Task ProcessPaymentAsync(Payment payment);

    Task RefundPaymentAsync(Guid id);
}