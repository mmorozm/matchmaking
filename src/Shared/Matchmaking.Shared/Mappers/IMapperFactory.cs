namespace Matchmaking.Shared.Mappers;

public interface IMapperFactory
{
    /// <summary>
    /// Gets a mapper for converting between specified types
    /// </summary>
    /// <typeparam name="TIn">The input type to convert from</typeparam>
    /// <typeparam name="TOut">The output type to convert to</typeparam>
    /// <returns>Mapper instance for the specified types</returns>
    IMatchmakingMapper<TIn, TOut> GetMapper<TIn, TOut>();
}