using System.Reflection;
using Matchmaking.Shared.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Matchmaking.Shared.Extensions;

public static class SharedExtensions
{
    public static IServiceCollection AddMappers(this IServiceCollection services, Assembly assembly)
    {
        var mapperType = typeof(IMatchmakingMapper<,>);

        var mapperTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperType));

        foreach (var type in mapperTypes)
        {
            var implementedInterface = type.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == mapperType);
            services.AddTransient(implementedInterface, type);
        }

        services.AddScoped<IMapperFactory, MapperFactory>();

        return services;
    }

    public static IApplicationBuilder UseMatchmakingHealthChecks(this IApplicationBuilder app)
    {
        return app.UseHealthChecks("/health", new HealthCheckOptions());
    }
}