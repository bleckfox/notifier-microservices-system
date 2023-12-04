using RabbitMQ.Client;
using Sender.AppSettings;
using System.Text;
using System.Threading.Channels;

namespace Sender.Services;

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

    public bool TryGetMessageFromQueue(out string jsonString, string queueName)
    {
        var queueDeclareOk = _channel.QueueDeclarePassive(queueName);

        // Если есть сообщение в очереди, попробуйте его прочитать
        if (queueDeclareOk.MessageCount > 0)
        {
            // Получение сообщения из очереди
            var result = _channel.BasicGet(queueName, autoAck: true);

            // Проверка наличия сообщения
            if (result != null)
            {
                jsonString = Encoding.UTF8.GetString(result.Body.ToArray());
                return true;
            }
        }

        jsonString = null;
        return false;
    }


    public void CloseConnection()
    {
        _channel.Close();
        _connection.Close();
    }
}
