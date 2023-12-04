namespace Api.Handlers;

public partial class BaseHandler
{
    protected object ReturnResult(bool result, int code, string? exceptionType = null)
    {
        if (result) return new { ok = true, status = code };

        return new
        {
            ok = false,
            status = code,
            error = exceptionType ?? "unknown"
        };
    }
}
