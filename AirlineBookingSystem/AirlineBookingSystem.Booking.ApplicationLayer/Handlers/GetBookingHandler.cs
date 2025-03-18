namespace AirlineBookingSystem.Booking.Application.Handlers;

using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Booking.Domain.Entities;
using AirlineBookingSystem.Booking.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

public class GetBookingHandler(IBookingRepository bookingRepository) : IRequestHandler<GetBookingQuery, Domain.Entities.Booking>
{
    private readonly IBookingRepository bookingRepository = bookingRepository;

    public async Task<Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
    {
        return await this.bookingRepository.GetBookingByIdAsync(request.Id) ?? throw new("no existe reserva");
    }
}