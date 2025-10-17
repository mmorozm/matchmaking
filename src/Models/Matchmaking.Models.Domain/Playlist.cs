using Matchmaking.Models.Domain.Enum;

namespace Matchmaking.Models.Domain;

public class Playlist
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public PlaylistType PlaylistType { get; set; }
    public ICollection<Scenario> Scenarios { get; set; }
}