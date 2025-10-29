using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Matchmaking.Models.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.RepositoriesImpl;

public class MatchRepository : IMatchRepository
{
    private readonly MatchmakingDbContext _context;

    public MatchRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<Match> CreateAsync(Match entity)
    {
        _context.Matches.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Match?> GetByIdAsync(Guid id)
    {
        return await _context.Matches.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<Match> GetAll()
    {
        return _context.Matches.AsQueryable();
    }

    public async Task<Match> UpdateAsync(Match entity)
    {
        _context.Matches.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Matches.FindAsync(id);
        if (entity != null)
        {
            _context.Matches.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _context.Matches.AnyAsync(e => e.Id == id);
    }

    // Example query helpers (adjust property names as needed):
    public IQueryable<Match> GetByScenarioId(int scenarioId)
    {
        return _context.Matches.Where(e => e.ScenarioId == scenarioId);
    }

    public IQueryable<Match> GetByPlaylistId(int playlistId)
    {
        return _context.Matches.Where(e => e.PlaylistId == playlistId);
    }

    public IQueryable<Match> GetByState(MatchState matchState)
    {
        return _context.Matches.Where(e => e.State == matchState);   
    }
}
