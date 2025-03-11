using System.Net;
using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payments.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Payment.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentCommand command)
    {
        var result = await this.mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("refund/{id}")]
    public async Task<IActionResult> RefundPayment([FromRoute] Guid id)
    {
        await this.mediator.Send(new RefundPaymentCommand(id));
        return Ok(HttpStatusCode.OK);
    }
}
