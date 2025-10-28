using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IScenarioRepository
{
    Task<Scenario> CreateAsync(Scenario entity);
    Task<Scenario?> GetByIdAsync(int id);
    IQueryable<Scenario> GetAll();
    Task<Scenario> UpdateAsync(Scenario entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
