using System.Text.Json;

namespace Api.Models;

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
    /// фио того, кому отправляем письмо
    /// </summary>
    public string ToFio { get; set; } = null!;

    /// <summary>
    /// событие для отправки
    /// </summary>
    public string Event { get; set; } = null!;


    public override string ToString() => JsonSerializer.Serialize(this);
}
