using Matchmaking.Models.Services.Requests;
using Matchmaking.Models.Services.Responses;

namespace Matchmaking.Models.Services;

public interface IClientService
{
    Task<TicketStatusResponse> RegisterTicketAsync(FindMatchRequest request);
    Task<TicketStatusResponse> GetTicketStatusAsync(Guid ticketId);
    Task<AssignedMatchResponse> GetAssignedMatchAsync(Guid ticketId);
}