using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Sender.AppSettings;
using Sender.Senders.Email.Builder;
using Sender.Senders.Email.Helpers;
using Sender.Senders.Email.Models;

namespace Sender.Senders;

/// <summary>
/// Сервис отправки уведомлений
/// </summary>
public static class Notifier
{
    public static async Task SendEmailAsync(EmailSettings emailSettings, EmailData emailData)
    {
        // Получаем тему письма
        emailData.Subject = EmailBodyHelper.GetSubject(emailData.Event);

        // Получаем тело письма
        emailData.Body = EmailBodyHelper.GetBody(emailData.ToFio, emailData.Event);

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(emailSettings.SenderName, emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress(emailData.ToFio, emailData.ToEmail));
        message.Subject = emailData.Subject;
        message.Body = new BodyBuilder
        {
            HtmlBody = new EmailBuilder()
                .AddHeader(emailData.Subject)
                .AddBody(emailData.Body)
                .AddFooter()
                .GetMessageBody()
        }.ToMessageBody();

        using var client = new SmtpClient();
        await client.ConnectAsync(emailSettings.SmtpServer, emailSettings.SmtpPort, SecureSocketOptions.SslOnConnect);
        await client.AuthenticateAsync(emailSettings.SmtpUsername, emailSettings.SmtpPassword);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
