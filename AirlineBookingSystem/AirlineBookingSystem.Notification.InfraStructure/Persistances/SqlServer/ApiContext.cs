using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirlineBookingSystem.Notification.InfraStructure.Persistances.SqlServer;

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

    public DbSet<Domain.Entities.Notification> Notifications { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Notification>()
            .ToTable("Notifications")
            .HasKey(b => b.Id);
    }
}