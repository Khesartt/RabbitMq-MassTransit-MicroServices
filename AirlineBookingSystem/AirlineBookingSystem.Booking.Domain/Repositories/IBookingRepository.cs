namespace AirlineBookingSystem.Booking.Domain.Repositories;

using AirlineBookingSystem.Booking.Domain.Entities;

public interface IBookingRepository
{
    Task<Booking?> GetBookingByIdAsync(Guid Id);

    Task AddBookingAsync(Booking booking);
}