using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Falc.Email.Infrastructure.Integrations.Mailgun.Messages;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddMessageService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHttpClient<IMessageService, MessageService>((provider, client) =>
        {
            var mailgunConfiguration = provider.GetRequiredService<IOptions<Configuration>>().Value;
            
            client.BaseAddress = new Uri($"https://api.mailgun.net/v3/{mailgunConfiguration.SenderDomain}/messages");
            var base64String = Convert.ToBase64String(Encoding.ASCII.GetBytes($"api:{mailgunConfiguration.ApiKey}"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64String);
        });
        
        return serviceCollection;
    }
}