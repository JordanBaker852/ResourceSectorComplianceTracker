using Microsoft.Extensions.DependencyInjection;

namespace ComplianceTracker.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, string mediatrLicenseKey)
    {
        services.AddMediatR(config =>
        {
            config.LicenseKey = mediatrLicenseKey;
            config.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
        });

        return services;
    }
}