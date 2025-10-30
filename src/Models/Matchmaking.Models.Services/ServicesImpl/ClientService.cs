using Matchmaking.Models.Services.Requests;
using Matchmaking.Models.Services.Responses;

namespace Matchmaking.Models.Services.ServicesImpl;

public class ClientService : IClientService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMatchReservationRepository _matchReservationRepository;
    private readonly IIntermediateLobbyRepository _intermediateLobbyRepository;
    
    public ClientService(
        ITicketRepository ticketRepository,
        IIntermediateLobbyRepository intermediateLobbyRepository,
        IMatchReservationRepository matchReservationRepository)
    {
        _ticketRepository = ticketRepository;
        _intermediateLobbyRepository = intermediateLobbyRepository;
        _matchReservationRepository = matchReservationRepository;
    }

    public async Task<TicketStatusResponse> RegisterTicketAsync(FindMatchRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<TicketStatusResponse> GetTicketStatusAsync(Guid ticketId)
    {
        throw new NotImplementedException();
    }

    public async Task<AssignedMatchResponse> GetAssignedMatchAsync(Guid ticketId)
    {
        throw new NotImplementedException();
    }
}