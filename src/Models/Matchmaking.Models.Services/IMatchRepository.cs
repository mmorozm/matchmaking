using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IMatchRepository
{
    Task<Match> CreateAsync(Match entity);
    Task<Match?> GetByIdAsync(Guid id);
    IQueryable<Match> GetAll();
    Task<Match> UpdateAsync(Match entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);

    // Query helpers (adjust as needed)
    IQueryable<Match> GetByScenarioId(int scenarioId);
    IQueryable<Match> GetByPlaylistId(int playlistId);
}
