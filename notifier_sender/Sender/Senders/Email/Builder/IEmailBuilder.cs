namespace Sender.Senders.Email.Builder;

public interface IEmailBuilder
{
    IEmailBuilder AddHeader(string title);
    IEmailBuilder AddBody(string body);
    IEmailBuilder AddFooter();

    string GetMessageBody();
}
