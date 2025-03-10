using AirlineBookingSystem.Payment.Domain.Repositories;
using AirlineBookingSystem.Payment.InfraStructure.Persistances.SqlServer;

namespace AirlineBookingSystem.Payment.InfraStructure.Repositories;

public class PaymentRepository(ApiContext context) : IPaymentRepository
{
    private readonly ApiContext _context = context;

    public async Task ProcessPaymentAsync(Domain.Entities.Payment payment)
    {
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
    }

    public async Task RefundPaymentAsync(Guid id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment != null)
        {
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
        }
    }
}