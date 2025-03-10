namespace AirlineBookingSystem.Payments.Application.Handlers;

using AirlineBookingSystem.Payment.Domain.Repositories;
using AirlineBookingSystem.Payment.Domain.Entities;
using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ProcessPaymentHandler(IPaymentRepository paymentRepository) : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository paymentRepository = paymentRepository;

    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };

        await this.paymentRepository.ProcessPaymentAsync(payment);

        return payment.Id;
    }
}