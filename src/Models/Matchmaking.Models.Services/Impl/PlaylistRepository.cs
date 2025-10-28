using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.Impl;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly MatchmakingDbContext _context;

    public PlaylistRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<Playlist> CreateAsync(Playlist entity)
    {
        _context.Playlists.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Playlist?> GetByIdAsync(int id)
    {
        return await _context.Playlists.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<Playlist> GetAll()
    {
        return _context.Playlists.AsQueryable();
    }

    public async Task<Playlist> UpdateAsync(Playlist entity)
    {
        _context.Playlists.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Playlists.FindAsync(id);
        if (entity != null)
        {
            _context.Playlists.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(int id)
    {
        return _context.Playlists.AnyAsync(e => e.Id == id);
    }
}
