using Api.AppSettings;
using RabbitMQ.Client;
using System.Text;

namespace Api.Services;

public class RabbitMqService
{
    private readonly RabbitMqSettings _mqSettings;
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqService(RabbitMqSettings mqSettings)
    {
        _mqSettings = mqSettings;

        var factory = new ConnectionFactory
        {
            HostName = _mqSettings.HostName,
            Port = mqSettings.Port,
            UserName = _mqSettings.UserName,
            Password = _mqSettings.Password
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public bool SendMessage(string message, string queueName)
    {
        _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);

        return true;
    }

    public void CloseConnection()
    {
        _channel.Close();
        _connection.Close();
    }
}
