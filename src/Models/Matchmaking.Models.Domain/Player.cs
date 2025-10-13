namespace Matchmaking.Models.Domain;

public class Player
{
    public string Platform { get; set; }

    public string PlatofrmId { get; set; }
    
    public override string ToString()
    {
        return $"{Platform.ToUpper()}:{PlatofrmId.ToUpper()}";
    }

    public static Player CreateFromStringArr(ICollection<string> playerData)
    {
        if (playerData.Count < 2)
        {
            return null;
        }

        return new Player
        {
            Platform = playerData.ElementAt(0),
            PlatofrmId = playerData.ElementAt(1)
        };
    }
}