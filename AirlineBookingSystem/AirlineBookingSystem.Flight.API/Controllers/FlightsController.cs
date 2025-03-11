namespace AirlineBookingSystem.Flight.API.Controllers;

using System.Net;
using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FlightsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetFlights()
    {
        var result = await this.mediator.Send(new GetAllFlightsQuery());
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
    {
        var result = await this.mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFlight([FromRoute] Guid id)
    {
        await this.mediator.Send(new DeleteFlightCommand(id));

        return Ok(HttpStatusCode.OK);
    }
}