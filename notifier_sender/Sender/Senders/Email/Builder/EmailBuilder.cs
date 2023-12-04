using Sender.Senders.Email.Models;

namespace Sender.Senders.Email.Builder;

public class EmailBuilder : IEmailBuilder
{
    private readonly EmailBody _emailBody;

    public EmailBuilder()
    {
        _emailBody = new EmailBody();
    }

    public IEmailBuilder AddHeader(string title)
    {
        _emailBody.Header = "<!DOCTYPE html>\n" +
                            "<html>\n" +
                            "  <head>\n" +
                            "      <meta charset=\"UTF-8\">\n" +
                            $"      <title>{title}</title>\n" +
                            "      <style>\n" +
                            "          body {\n" +
                            "              font-family: Arial, sans-serif;\n" +
                            "              background-color: #f1f1f1;\n" +
                            "              margin: 0;\n" +
                            "              padding: 0;\n" +
                            "              }\n\n        " +
                            "          .container {\n" +
                            "              max-width: 600px;\n" +
                            "              margin: 0 auto;\n" +
                            "              padding: 20px;\n" +
                            "              }\n\n" +
                            "          h1 {\n" +
                            "              color: #333;\n" +
                            "              font-size: 24px;\n" +
                            "              margin-bottom: 20px;\n" +
                            "              }\n\n" +
                            "          p {\n" +
                            "              color: #666;\n" +
                            "              font-size: 16px;\n" +
                            "              line-height: 1.5;\n" +
                            "              margin-bottom: 10px;\n" +
                            "              }\n\n" +
                            "          .button {\n" +
                            "              display: inline-block;\n" +
                            "              padding: 10px 20px;\n" +
                            "              background-color: #3498db;\n" +
                            "              color: #fff;\n" +
                            "              text-decoration: none;\n" +
                            "              border-radius: 4px;\n" +
                            "              }\n    " +
                            "      </style>\n" +
                            "  </head>\n" +
                            "  <body>\n" +
                            "      <div class=\"container\">\n";

        return this;
    }

    public IEmailBuilder AddBody(string body)
    {
        _emailBody.Body = body;

        return this;
    }

    public IEmailBuilder AddFooter()
    {
        _emailBody.Footer = "      </div>\n" +
                            "  </body>\n" +
                            "</html>\n";

        return this;
    }

    public string GetMessageBody()
    {
        return _emailBody.ToString();
    }
}
