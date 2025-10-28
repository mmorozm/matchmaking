using Matchmaking.Models.Domain;

namespace Matchmaking.Models.Services;

public interface IPlaylistRepository
{
    Task<Playlist> CreateAsync(Playlist entity);
    Task<Playlist?> GetByIdAsync(int id);
    IQueryable<Playlist> GetAll();
    Task<Playlist> UpdateAsync(Playlist entity);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}
