namespace AirlineBookingSystem.Flight.InfraStructure.Persistances.SqlServer;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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

    public DbSet<Domain.Entities.Flight> Flights { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Flight>()
            .ToTable("Flights")
            .HasKey(b => b.Id);
    }
}