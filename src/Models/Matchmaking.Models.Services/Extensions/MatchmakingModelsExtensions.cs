using Microsoft.Extensions.DependencyInjection;
using Matchmaking.Models.Services.RepositoriesImpl;
using Matchmaking.Models.Services.ServicesImpl;

namespace Matchmaking.Models.Services.Extensions;

public static class MatchmakingModelsExtensions
{
    public static IServiceCollection AddMatchmakingRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<IPlatformGroupRepository, PlatformGroupRepository>();
        services.AddScoped<IPlaylistRepository, PlaylistRepository>();
        services.AddScoped<IMatchReservationRepository, MatchReservationRepository>();
        services.AddScoped<IMatchRepository, MatchRepository>();
        services.AddScoped<IIntermediateLobbyRepository, IntemediateLobbyRepository>();

        return services;
    }

    public static IServiceCollection AddMatchmakingServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        
        return services;
    }


}