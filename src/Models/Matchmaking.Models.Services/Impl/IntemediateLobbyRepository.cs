using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.Impl;

public class IntemediateLobbyRepository : IIntermediateLobbyRepository
{
    private readonly MatchmakingDbContext _context;

    public IntemediateLobbyRepository(MatchmakingDbContext context)
    {
        _context = context;
    }
    public async Task<IntermediateLobby> CreateAsync(IntermediateLobby entity)
    {
        _context.IntermediateLobby.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IntermediateLobby?> GetByIdAsync(Guid id)
    {
        return await _context.IntermediateLobby.FirstOrDefaultAsync(t => t.Id == id);
    }

    public IQueryable<IntermediateLobby> GetAll()
    {
        return _context.IntermediateLobby.AsQueryable();
    }

    public async Task<IntermediateLobby> UpdateAsync(IntermediateLobby entity)
    {
        _context.IntermediateLobby.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var lobby = await _context.IntermediateLobby.FindAsync(id);
        if (lobby != null)
        {
            _context.IntermediateLobby.Remove(lobby);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _context.IntermediateLobby.AnyAsync(t => t.Id == id);
    }
}