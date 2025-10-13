namespace Matchmaking.Models.Domain;

public class Playlist
{
    public int Id { get; set; }

    public string Name { get; set; }

    public PlaylistType PLaylistType { get; set; }
    public ICollection<Scenario> Scenarios { get; set; }
}