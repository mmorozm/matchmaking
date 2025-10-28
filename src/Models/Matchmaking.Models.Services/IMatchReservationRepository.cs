using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IMatchReservationRepository
{
    Task<MatchReservation> CreateAsync(MatchReservation entity);
    Task<MatchReservation?> GetByIdAsync(Guid id);
    IQueryable<MatchReservation> GetAll();
    Task<MatchReservation> UpdateAsync(MatchReservation entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);

    // Query helpers (adjust as needed)
    IQueryable<MatchReservation> GetByMatchId(Guid matchId);
}
