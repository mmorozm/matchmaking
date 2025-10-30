namespace Matchmaking.Models.Services.Responses;

public class AssignedMatchResponse : TicketStatusResponse
{
    public MatchConnectionResponse? ConnectionData { get; set; }
}