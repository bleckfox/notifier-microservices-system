using Api.Models;
using Api.Services;
using RabbitMQ.Client;
using System.Text;

namespace Api.Handlers;

public class SendEmailHandler : BaseHandler
{
    private readonly RabbitMqService _rabbitMqService;

    public SendEmailHandler(RabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    public object SendEmail(EmailData data)
    {
        // Вызов rabbitMQ
        _rabbitMqService.SendMessage(data.ToString(), "email_queue");
        _rabbitMqService.CloseConnection();

        //var factory = new ConnectionFactory() { HostName = "" };

        //using var connection = factory.CreateConnection();
        //using var channel = connection.CreateModel();
        
        //// создаем очередь
        //channel.QueueDeclare(queue: "email_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        //var body = Encoding.UTF8.GetBytes("");

        //// отправляем сообщение в очередь
        //channel.BasicPublish(exchange: "", routingKey: "email_queue", basicProperties: null, body: body);

        return ReturnResult(true, StatusCodes.Status200OK);
    }
}
