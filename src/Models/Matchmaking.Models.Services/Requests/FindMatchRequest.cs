namespace Matchmaking.Models.Services.Requests;

public class FindMatchRequest
{
    public string PlayerId { get; set; }
    public ICollection<string> Party { get; set; }
    public Guid LateJoinTicketId { get; set; }
    public ICollection<Guid> RegionIds { get; set; }
    public ICollection<Guid> PlaylistIds { get; set; }

    public InputDeviceRequest PreferredInput { get; set; }
    
    public InputDeviceRequest OriginalInput { get; set; }

    public bool CrossplayEnabled { get; set; }

    public FindMatchRequest()
    {
        Party = new List<string>();
        RegionIds = new List<Guid>();
        PlaylistIds = new List<Guid>();
    }
}