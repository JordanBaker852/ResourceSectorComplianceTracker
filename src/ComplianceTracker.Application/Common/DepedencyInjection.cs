using Microsoft.Extensions.DependencyInjection;

namespace ComplianceTracker.Application;

public static class DepedencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, string mediatrLicenseKey)
    {
        services.AddMediatR(config =>
        {
            config.LicenseKey = mediatrLicenseKey;
            config.RegisterServicesFromAssemblies(typeof(DepedencyInjection).Assembly);
        });

        return services;
    }
}