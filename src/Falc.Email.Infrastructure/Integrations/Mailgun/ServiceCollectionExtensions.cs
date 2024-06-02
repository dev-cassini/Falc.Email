using Microsoft.Extensions.DependencyInjection;

namespace Falc.Email.Infrastructure.Integrations.Mailgun;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMailgunConfiguration(
        this IServiceCollection serviceCollection,
        Action<Configuration> configurationAction)
    {
        serviceCollection
            .AddOptions<Configuration>()
            .Configure(configurationAction);

        return serviceCollection;
    }
}