using System.Text.Json;
using Sender;
using Sender.AppSettings;
using Sender.Services;

// ѕолучение настроек дл€ почтового stmp сервера
var emailSettings = new EmailSettings();

using (HttpClient client = new HttpClient())
{
    string url = "http://settings_agent/get_settings/email";

    HttpResponseMessage response = await client.GetAsync(url);

    if (response.IsSuccessStatusCode)
    {
        string responseBody = await response.Content.ReadAsStringAsync();
        emailSettings = JsonSerializer.Deserialize<EmailSettings>(responseBody);
    }
    else
    {
        throw new ArgumentNullException("There is no an email settings data");
    }
}

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton(typeof(RabbitMqSettings));
        services.AddTransient(typeof(RabbitMqService));
        services.AddSingleton(emailSettings!);
    })
    .Build();

await host.RunAsync();
