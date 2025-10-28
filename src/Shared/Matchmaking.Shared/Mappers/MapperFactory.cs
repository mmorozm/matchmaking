using Microsoft.Extensions.DependencyInjection;

namespace Matchmaking.Shared.Mappers;

public class MapperFactory : IMapperFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MapperFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMatchmakingMapper<TIn, TOut> GetMapper<TIn, TOut>()
    {
        return _serviceProvider.GetRequiredService<IMatchmakingMapper<TIn, TOut>>();
    }
}