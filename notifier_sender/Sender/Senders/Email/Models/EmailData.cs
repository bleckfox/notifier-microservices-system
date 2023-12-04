using System.Text.Json;

namespace Sender.Senders.Email.Models;

/// <summary>
/// Данные для отправки письма
/// </summary>
public class EmailData
{
    /// <summary>
    /// почта того, кому отправляем письмо
    /// </summary>
    public string ToEmail { get; set; } = null!;

    /// <summary>
    /// тема письма
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// событие для отправки
    /// </summary>
    public string Event { get; set; } = null!;

    /// <summary>
    /// фио того, кому отправляем письмо
    /// </summary>
    public string ToFio { get; set; } = null!;

    /// <summary>
    /// тело письма
    /// </summary>
    public string Body { get; set; } = string.Empty;


    public override string ToString() => JsonSerializer.Serialize(this);
}
