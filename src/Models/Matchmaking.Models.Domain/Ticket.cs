using System.ComponentModel.DataAnnotations.Schema;

namespace Matchmaking.Models.Domain;

public class Ticket
{
    public Guid Id { get; set; }

    public string PlayerId { get; set; }

    public ICollection<string> Party { get; set; }

    public ICollection<Region> Regions { get; set; }

    public InputDevice SelectedInput { get; set; }
    
    public InputDevice OriginalInput { get; set; }

    public DateTime TimeCreated { get; set; }

    public TicketState State { get; set; }

    public int Size { get; set; }
    
    public Guid? LateJoinTicketId { get; set; }

    public Ticket? LateJoinTicket { get; set; }

    public ICollection<Ticket>? ChildTickets { get; set; }
}