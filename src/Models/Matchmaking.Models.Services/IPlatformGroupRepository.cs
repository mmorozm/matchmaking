using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IPlatformGroupRepository
{
    Task<PlatformGroup> CreateAsync(PlatformGroup entity);
    Task<PlatformGroup?> GetByIdAsync(int id);
    IQueryable<PlatformGroup> GetAll();
    Task<PlatformGroup> UpdateAsync(PlatformGroup entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
