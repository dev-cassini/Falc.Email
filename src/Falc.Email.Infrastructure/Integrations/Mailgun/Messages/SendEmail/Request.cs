namespace Falc.Email.Infrastructure.Integrations.Mailgun.Messages.SendEmail;

public record Request(
    string From,
    string To,
    string Subject,
    string Html);