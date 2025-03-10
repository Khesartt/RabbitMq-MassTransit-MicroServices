using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirlineBookingSystem.Payment.InfraStructure.Persistances.SqlServer;

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

    public DbSet<Domain.Entities.Payment> Payments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Payment>()
            .ToTable("Payments")
            .HasKey(b => b.Id);
    }
}
