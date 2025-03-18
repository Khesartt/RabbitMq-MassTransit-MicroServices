namespace AirlineBookingSystem.Payments.Application.Commands;

using MediatR;
using System;

public record ProcessPaymentCommand(Guid BookingId, decimal Amount) : IRequest<Guid>;