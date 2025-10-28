namespace Matchmaking.Models.Domain;

public class MatchReservation
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid MatchId { get; set; }
    public int TeamId { get; set; }
    public bool Present { get; set; }
    public DateTime PresentChanged { get; set; }
    public bool Registered { get; set; }
    public DateTime RegisteredChanged { get; set; }
    
    public Ticket Ticket { get; set; }
    public Match Match { get; set; }
}