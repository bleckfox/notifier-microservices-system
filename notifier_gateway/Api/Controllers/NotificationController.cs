using Api.Handlers;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/v1/notification")]
public class NotificationController : BaseController<NotificationController>
{
    private readonly SendEmailHandler _sendEmailHandler;
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(SendEmailHandler sendEmailHandler, ILogger<NotificationController> logger)
    {
        _sendEmailHandler = sendEmailHandler;
        _logger = logger;
    }

    [HttpPost("send_email")]
    public IActionResult SendEmail([FromBody] EmailData data)
    {
        try
        {
            // в данном примере не используется async - await, поэтому возвращаем просто IActionResult
            return Ok(_sendEmailHandler.SendEmail(data));
        }
        catch (Exception e)
        {
            LogError(_logger, e, $"Fail to send email - data -> {data}");
            return ReturnUnprocessableEntity("failed");
        }
    }
}
