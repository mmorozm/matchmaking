using System.ComponentModel.DataAnnotations.Schema;

namespace Matchmaking.Models.Domain;

public class Match
{
    public Guid Id { get; set; }

    public Region Region { get; set; }

    public InputDevice SupportedInputs { get; set; }
    
    public int PlatformId { get; set; }
    
    public PlatformGroup Platform { get; set; }
}