using AirlineBookingSystem.BuildingBlocks.Common;
using AirlineBookingSystem.Notification.Application.Consumers;
using AirlineBookingSystem.Notification.Application.Handlers;
using AirlineBookingSystem.Notification.Application.Interfaces;
using AirlineBookingSystem.Notification.Application.Services;
using AirlineBookingSystem.Notification.Domain.Repositories;
using AirlineBookingSystem.Notification.InfraStructure.Persistances.SqlServer;
using AirlineBookingSystem.Notification.InfraStructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();

var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(SendNotificationHandler).Assembly
};

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

builder.Services.AddMassTransit(config =>
{
    //cosumer stuffs
    config.AddConsumer<PaymentProcessedConsumer>();


    config.UsingRabbitMq((context, configuration) =>
    {

        configuration.Host(builder.Configuration["EventBusSettings:HostAddress"]);
        configuration.ReceiveEndpoint(EventBusConstant.PaymentProcessedQueue, c =>
        {
            c.ConfigureConsumer<PaymentProcessedConsumer>(context);
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
