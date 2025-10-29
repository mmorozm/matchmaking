using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.RepositoriesImpl;

public class PlatformGroupRepository : IPlatformGroupRepository
{
    private readonly MatchmakingDbContext _context;

    public PlatformGroupRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<PlatformGroup> CreateAsync(PlatformGroup entity)
    {
        _context.Platforms.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<PlatformGroup?> GetByIdAsync(int id)
    {
        return await _context.Platforms.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<PlatformGroup> GetAll()
    {
        return _context.Platforms.AsQueryable();
    }

    public async Task<PlatformGroup> UpdateAsync(PlatformGroup entity)
    {
        _context.Platforms.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Platforms.FindAsync(id);
        if (entity != null)
        {
            _context.Platforms.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(int id)
    {
        return _context.Platforms.AnyAsync(e => e.Id == id);
    }
}
