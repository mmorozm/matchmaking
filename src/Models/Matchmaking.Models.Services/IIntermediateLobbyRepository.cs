using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IIntermediateLobbyRepository
{
    Task<IntermediateLobby> CreateAsync(IntermediateLobby entity);
    Task<IntermediateLobby?> GetByIdAsync(Guid id);
    IQueryable<IntermediateLobby> GetAll();
    Task<IntermediateLobby> UpdateAsync(IntermediateLobby entity);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}