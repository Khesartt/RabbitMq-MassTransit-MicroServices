namespace AirlineBookingSystem.Payments.Application.Handlers;

using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class RefundPaymentHandler(IPaymentRepository paymentRepository) : IRequestHandler<RefundPaymentCommand>
{
    private readonly IPaymentRepository paymentRepository = paymentRepository;

    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await this.paymentRepository.RefundPaymentAsync(request.PaymentId);
    }
}