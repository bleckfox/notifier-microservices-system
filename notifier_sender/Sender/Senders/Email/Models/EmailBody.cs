using System.Text;

namespace Sender.Senders.Email.Models;

/// <summary>
/// Тело e-mail письма
/// </summary>
public class EmailBody
{
    /// <summary>
    /// Заголовок тела html письма
    /// </summary>
    public string Header { get; set; } = null!;

    /// <summary>
    /// Содержание тела html письма
    /// </summary>
    public string Body { get; set; } = null!;

    /// <summary>
    /// Подвал тела html письма
    /// </summary>
    public string Footer { get; set; } = null!;

    public override string ToString() =>
        new StringBuilder()
            .Append(Header)
            .Append(Body)
            .Append(Footer)
            .ToString();
}
