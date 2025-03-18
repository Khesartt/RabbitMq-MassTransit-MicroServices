using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirlineBookingSystem.Booking.InfraStructure.Persistances.SqlServer;

public class ApiContext : DbContext
{
    private readonly IConfiguration? _configuration;

    public ApiContext()
    {
    }
    public ApiContext(DbContextOptions<ApiContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Domain.Entities.Booking> Bookings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Booking>()
            .ToTable("Bookings")
            .HasKey(b => b.Id);
    }
}