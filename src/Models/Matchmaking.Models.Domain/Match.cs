using System.ComponentModel.DataAnnotations.Schema;
using Matchmaking.Models.Domain.Enum;

namespace Matchmaking.Models.Domain;

public class Match
{
    public Guid Id { get; set; }
    public MatchState State { get; set; }
    public Region Region { get; set; }
    public InputDevice SupportedInputs { get; set; }
    public int PlatformId { get; set; }
    public PlatformGroup Platform { get; set; }
    public int PlaylistId { get; set; }
    public Playlist Playlist { get; set; }
    public int ScenarioId { get; set; }
    public Scenario Scenario { get; set; }
    public ICollection<MatchReservation>? Reservations { get; set; }
}