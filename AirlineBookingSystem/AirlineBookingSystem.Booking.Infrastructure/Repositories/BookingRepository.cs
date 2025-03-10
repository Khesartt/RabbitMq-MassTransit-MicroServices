namespace AirlineBookingSystem.Booking.InfraStructure.Repositories;

using AirlineBookingSystem.Booking.Domain.Entities;
using AirlineBookingSystem.Booking.Domain.Repositories;
using AirlineBookingSystem.Booking.InfraStructure.Persistances.SqlServer;
using System;
using System.Threading.Tasks;

public class BookingRepository(ApiContext context) : IBookingRepository
{
    private readonly ApiContext context = context;

    public async Task AddBookingAsync(Booking booking)
    {
        this.context.Bookings.Add(booking);

        await this.context.SaveChangesAsync();
    }

    public async Task<Booking?> GetBookingByIdAsync(Guid id)
    {
        return await this.context.Bookings.FindAsync(id);
    }
}