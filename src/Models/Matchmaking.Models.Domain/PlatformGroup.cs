namespace Matchmaking.Models.Domain;

public class PlatformGroup
{
    public int Id { get; set; }

    public ICollection<string> Group { get; set; }
}