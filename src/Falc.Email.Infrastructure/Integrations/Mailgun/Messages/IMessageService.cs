namespace Falc.Email.Infrastructure.Integrations.Mailgun.Messages;

public interface IMessageService
{
    Task<SendEmail.Response> SendEmailAsync(SendEmail.Request request);
}