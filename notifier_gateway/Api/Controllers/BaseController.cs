using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
public class BaseController<T> : ControllerBase
{
    protected void LogError(ILogger logger, Exception e, string? message)
    {
        logger.LogError(e, $"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - {message} -> {e.InnerException?.Message ?? e.Message}");
    }

    protected void LogInformation(ILogger logger, string message)
    {
        logger.LogInformation($"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - {message}");
    }

    protected IActionResult ReturnUnprocessableEntity(string exceptionType)
    {
        return UnprocessableEntity(new
        {
            ok = false,
            status = StatusCodes.Status422UnprocessableEntity,
            error = exceptionType
        });
    }
}
