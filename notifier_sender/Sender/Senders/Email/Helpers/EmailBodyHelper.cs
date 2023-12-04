using System.Text;

namespace Sender.Senders.Email.Helpers;

/// <summary>
/// Хелпер для работы с телом e-mail сообщения
/// </summary>
public static class EmailBodyHelper
{
    /// <summary>
    /// Добавление html строки в письмо
    /// </summary>
    /// <param name="tag">Html тэг</param>
    /// <param name="text">Текст</param>
    /// <returns>Строка html для добавления в шаблон письма</returns>
    private static string AddHtmlLine(string tag, string text)
    {
        return $"<{tag}>{text}</{tag}>\n";
    }

    /// <summary>
    /// Получение темы письма
    /// </summary>
    /// <param name="emailEvent">Событие для отправки письма</param>
    /// <returns>Тело письма</returns>
    public static string GetSubject(string emailEvent)
    {
        return emailEvent switch
        {
            "register" => "Добро пожаловать!",
            _ => "Системное уведомление"
        };
    }

    /// <summary>
    /// Получение тела сообщения для письма
    /// </summary>
    /// <param name="userName">Имя пользователя</param>
    /// <param name="userSurname">Фамилия пользователя</param>
    /// <param name="emailEvent">Событые отправки письма</param>
    /// <param name="data">Код подтверждения (необязательно)</param>
    /// <returns></returns>
    public static string GetBody(string userName, string emailEvent)
    {
        string header = AddHtmlLine("h1", $"Доброго дня, {userName}!"); ;
        string footer = AddHtmlLine("p", "С уважением, команда поддержки.");

        return emailEvent switch
        {
            "register" => new StringBuilder()
                .Append(header)
                .Append(AddHtmlLine("p", "Добро пожаловать. Мы рады видеть вас, как нового пользователя!"))
                .Append(AddHtmlLine("p", $"Воспользуйтесь формой входа для получения кода подтверждения доступа."))
                .Append(footer)
                .ToString(),
            "sign_in" => new StringBuilder()
                .Append(header)
                .Append(AddHtmlLine("p", "Добро пожаловать. Для вас создан код подтверждения входа!"))
                .Append(AddHtmlLine("p", $"Ваш код - сгенерированный_код"))
                .Append(AddHtmlLine("p", $"Он будет действовать 5 минут, иначе надо запросить снова."))
                .Append(footer)
                .ToString(),
            _ => new StringBuilder()
                .Append(header)
                .Append(AddHtmlLine("p", "Это письмо сформировано автоматически внутренней службой, отвечать на него нужно. Проводятся технические работы."))
                .Append(AddHtmlLine("p", "Простите за беспокойство"))
                .Append(footer)
                .ToString()
        };
    }
}
