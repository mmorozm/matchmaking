using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.Impl;

public class ScenarioRepository : IScenarioRepository
{
    private readonly MatchmakingDbContext _context;

    public ScenarioRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<Scenario> CreateAsync(Scenario entity)
    {
        _context.Scenarios.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Scenario?> GetByIdAsync(int id)
    {
        return await _context.Scenarios.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<Scenario> GetAll()
    {
        return _context.Scenarios.AsQueryable();
    }

    public async Task<Scenario> UpdateAsync(Scenario entity)
    {
        _context.Scenarios.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Scenarios.FindAsync(id);
        if (entity != null)
        {
            _context.Scenarios.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(int id)
    {
        return _context.Scenarios.AnyAsync(e => e.Id == id);
    }
}
