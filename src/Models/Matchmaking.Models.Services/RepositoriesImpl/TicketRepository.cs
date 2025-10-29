using Matchmaking.Migrations.Data;
using Matchmaking.Models.Domain;
using Matchmaking.Models.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace Matchmaking.Models.Services.RepositoriesImpl;

public class TicketRepository : ITicketRepository
{
    private readonly MatchmakingDbContext _context;

    public TicketRepository(MatchmakingDbContext context)
    {
        _context = context;
    }

    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        return await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);
    }

    public IQueryable<Ticket> GetAll()
    {
        return _context.Tickets.AsQueryable();
    }

    public async Task<Ticket> UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    public async Task DeleteAsync(Guid id)
    {
        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }

    public IQueryable<Ticket> GetByPlayerId(string playerId)
    {
        return _context.Tickets.Where(t => t.PlayerId == playerId);
    }

    public IQueryable<Ticket> GetByState(TicketState state)
    {
        return _context.Tickets.Where(t => t.State == state);
    }

    public IQueryable<Ticket> GetChildTickets(Guid parentId)
    {
        return _context.Tickets.Where(t => t.LateJoinTicketId == parentId);
    }

    public Task<bool> ExistsAsync(Guid id)
    {
        return _context.Tickets.AnyAsync(t => t.Id == id);
    }
}