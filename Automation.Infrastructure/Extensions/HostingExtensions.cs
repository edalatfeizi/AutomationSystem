
using Automation.Infrastructure.Repositories;

namespace Automation.Infrastructure.Extensions;

public static class HostingExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AutomationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        return services;
    }
}
