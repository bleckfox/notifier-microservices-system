using System.Text.Json;

namespace Sender.AppSettings;

/// <summary>
/// Модель настроек почтового stmp сервера
/// </summary>
public class EmailSettings
{
    /// <summary>
    /// Адрес SMTP-сервера
    /// </summary>
    public string SmtpServer { get; set; } = null!;

    /// <summary>
    /// Порт SMTP-сервера
    /// </summary>
    public int SmtpPort { get; set; }

    /// <summary>
    /// Имя пользователя для аутентификации на SMTP-сервере
    /// </summary>
    public string SmtpUsername { get; set; } = null!;

    /// <summary>
    /// Пароль для аутентификации на SMTP-сервере
    /// </summary>
    public string SmtpPassword { get; set; } = null!;

    /// <summary>
    /// Имя отправителя письма
    /// </summary>
    public string SenderName { get; set; } = null!;

    /// <summary>
    /// Адрес отправителя письма
    /// </summary>
    public string SenderEmail { get; set; } = null!;

    public override string ToString() => JsonSerializer.Serialize(this);
}
