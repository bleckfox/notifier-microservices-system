using Sender.AppSettings;
using Sender.Senders;
using Sender.Senders.Email.Models;
using Sender.Services;
using System.Text.Json;

namespace Sender
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly EmailSettings _emailSettings;
        private readonly RabbitMqService _rabbitMqService;

        public Worker(ILogger<Worker> logger, EmailSettings emailSettings, RabbitMqService rabbitMqService)
        {
            _logger = logger;
            _emailSettings = emailSettings;
            _rabbitMqService = rabbitMqService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_rabbitMqService.TryGetMessageFromQueue(out string jsonString, "email_queue"))
                {
                    try
                    {
                        // Десериализация строки JSON в объект EmailData
                        EmailData emailData = JsonSerializer.Deserialize<EmailData>(jsonString)!;
                        _logger.LogInformation($"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - emailData -> {emailData}");
                        _logger.LogInformation($"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - emailSettings -> {_emailSettings}");

                        // Отправка письма
                        await Notifier.SendEmailAsync(_emailSettings, emailData);

                        _logger.LogInformation($"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - message was sent - data -> {emailData}");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"{DateTime.Now.ToUniversalTime:dd.MM.yyyy - HH:mm:ss} - fail to send email - data -> {jsonString}");
                    }
                    
                }
                
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}