using AirlineBookingSystem.Booking.Application.Consumers;
using AirlineBookingSystem.Booking.Application.Handlers;
using AirlineBookingSystem.Booking.Domain.Repositories;
using AirlineBookingSystem.Booking.InfraStructure.Persistances.SqlServer;
using AirlineBookingSystem.Booking.InfraStructure.Repositories;
using AirlineBookingSystem.BuildingBlocks.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookingRepository, BookingRepository>();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(CreateBookingHandler).Assembly,
    typeof(GetBookingHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddMassTransit(config =>
{
    //cosumer stuffs

    config.AddConsumer<NotificationEventConsumer>();
    config.UsingRabbitMq((context, configuration) =>
    {

        configuration.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        configuration.ReceiveEndpoint(EventBusConstant.NotificationQueue, c =>
        {
            c.ConfigureConsumer<NotificationEventConsumer>(context);
        });
    });

});





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