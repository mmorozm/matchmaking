using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.Impl;

public class MatchReservationRepository : IMatchReservationRepository
{
    private readonly MatchmakingDbContext _context;

    public MatchReservationRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<MatchReservation> CreateAsync(MatchReservation entity)
    {
        _context.Reservations.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<MatchReservation?> GetByIdAsync(Guid id)
    {
        return await _context.Reservations.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<MatchReservation> GetAll()
    {
        return _context.Reservations.AsQueryable();
    }

    public async Task<MatchReservation> UpdateAsync(MatchReservation entity)
    {
        _context.Reservations.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Reservations.FindAsync(id);
        if (entity != null)
        {
            _context.Reservations.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _context.Reservations.AnyAsync(e => e.Id == id);
    }

    // Example query helpers (adjust property names as needed):
    public IQueryable<MatchReservation> GetByMatchId(Guid matchId)
    {
        return _context.Reservations.Where(e => e.MatchId == matchId);
    }
}
