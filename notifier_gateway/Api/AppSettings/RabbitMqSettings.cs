namespace Api.AppSettings;

/// <summary>
/// Настройки подключения к rabbitMQ
/// </summary>
public class RabbitMqSettings
{
    private readonly IConfiguration _configuration;

    public RabbitMqSettings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string HostName => _configuration.GetSection("RabbitMQ").GetSection("Host").Value!;
    public int Port => Convert.ToInt32(_configuration.GetSection("RabbitMQ").GetSection("Port").Value!);
    public string UserName => _configuration.GetSection("RabbitMQ").GetSection("UserName").Value!;
    public string Password => _configuration.GetSection("RabbitMQ").GetSection("Password").Value!;
}
