namespace Matchmaking.Models.Services.Responses;

public class FindMatchResponse
{
    public Guid TicketId { get; set; }

    public TicketStateResponse State { get; set; }

    public string Message { get; set; }
}