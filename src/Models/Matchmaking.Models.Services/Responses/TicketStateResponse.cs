namespace Matchmaking.Models.Services.Responses;

public enum TicketStateResponse
{
    None = 0,
    Searching = 1,
    MatchReady = 2,
    InMatch = 3,
    LateJoin = 4,
    Cancelled = 5,
    Error = 6,
}