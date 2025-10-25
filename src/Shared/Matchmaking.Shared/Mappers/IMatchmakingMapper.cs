namespace Matchmaking.Shared.Mappers;

/// <summary>
/// Generic mapper interface for converting between types
/// </summary>
/// <typeparam name="Tin">The input type to convert from</typeparam>
/// <typeparam name="Tout">The output type to convert to</typeparam>
public interface IMatchmakingMapper<Tin, Tout>
{
    /// <summary>
    /// Maps an input object to output type
    /// </summary>
    /// <param name="input">The input object to map</param>
    /// <returns>Mapped output object</returns>
    Tout Map(Tin input);
}