using Matchmaking.Models.Domain.Enum;

namespace Matchmaking.Models.Domain;

public class IntermediateLobby
{
    public Guid Id { get; set; }

    public ICollection<Region> Regions { get; set; }

    public int PlatformGroupId { get; set; }
    
    public PlatformGroup Group { get; set; }

    public InputDevice DevicePreferences { get; set; }

    public uint ClientVersion { get; set; }
}