namespace AirlineBookingSystem.Payment.Application.Commands;

using MediatR;

public record RefundPaymentCommand(Guid PaymentId) : IRequest;