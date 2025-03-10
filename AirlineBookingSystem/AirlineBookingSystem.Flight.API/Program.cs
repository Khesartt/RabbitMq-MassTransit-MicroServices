using AirlineBookingSystem.Flight.Domain.Repositories;
using AirlineBookingSystem.Flight.InfraStructure.Persistances.SqlServer;
using AirlineBookingSystem.Flight.InfraStructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFlightRepository, FlightRepository>();


builder.Services.AddDbContext<ApiContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("defautlConnection");
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
