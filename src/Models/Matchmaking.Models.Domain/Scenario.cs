namespace Matchmaking.Models.Domain;

public class Scenario
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int PlaylistId { get; set; }

    public Playlist Playlist { get; set; }
}