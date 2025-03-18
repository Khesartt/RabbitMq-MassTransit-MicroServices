namespace AirlineBookingSystem.Payments.Application.Handlers;

using AirlineBookingSystem.Payment.Domain.Repositories;
using AirlineBookingSystem.Payment.Domain.Entities;
using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBusMessages;

public class ProcessPaymentHandler(IPaymentRepository paymentRepository, IPublishEndpoint publishEndpoint) : IRequestHandler<ProcessPaymentCommand, Guid>
{
    private readonly IPaymentRepository paymentRepository = paymentRepository;
    private readonly IPublishEndpoint publishEndpoint = publishEndpoint;

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

        // Publish PaymentProcessedEvent


            await this.publishEndpoint.Publish(new PaymentProcessedEvent(payment.Id, payment.BookingId, payment.Amount, payment.PaymentDate));

        return payment.Id;
    }
}