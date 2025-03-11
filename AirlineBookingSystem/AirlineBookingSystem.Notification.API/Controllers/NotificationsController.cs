using System.Net;
using AirlineBookingSystem.Notification.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Notification.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] SendNotificationCommand command)
    {
        await this.mediator.Send(command);

        return Ok(HttpStatusCode.OK);
    }
}