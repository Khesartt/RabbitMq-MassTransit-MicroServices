namespace AirlineBookingSystem.Booking.API.Controllers;

using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BookingsController(IMediator mediator) : ControllerBase
{

    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
    {
        var result = await this.mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBooking([FromRoute] Guid id)
    {
        var result = await this.mediator.Send(new GetBookingQuery(id));
        return Ok(result);
    }
}