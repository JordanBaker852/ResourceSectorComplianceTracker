using ComplianceTracker.Application.Interfaces;
using ComplianceTracker.Infrastructure.Persistance;
using ComplianceTracker.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ComplianceTracker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
            .UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IWorkerRepository, WorkerRepository>();

        return services;
    }
}