namespace Falc.Email.Infrastructure.Integrations.Mailgun;

public class Configuration
{
    public string ApiKey { get; init; } = string.Empty;
    public string SenderDomain { get; init; } = string.Empty;
}