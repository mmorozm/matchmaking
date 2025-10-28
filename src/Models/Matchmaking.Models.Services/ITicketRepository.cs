using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matchmaking.Models.Domain;
using Matchmaking.Models.Domain.Enum;

namespace Matchmaking.Models.Services;

public interface ITicketRepository
{
    Task<Ticket> CreateAsync(Ticket ticket);
    Task<Ticket?> GetByIdAsync(Guid id);
    IQueryable<Ticket> GetAll();
    Task<Ticket> UpdateAsync(Ticket ticket);
    Task DeleteAsync(Guid id);
    IQueryable<Ticket> GetByPlayerId(string playerId);
    IQueryable<Ticket> GetByState(TicketState state);
    IQueryable<Ticket> GetChildTickets(Guid parentId);
    Task<bool> ExistsAsync(Guid id);
}