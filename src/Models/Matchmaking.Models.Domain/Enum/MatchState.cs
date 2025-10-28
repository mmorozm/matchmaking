namespace Matchmaking.Models.Domain.Enum;

public enum MatchState
{
    Created,
    Searching,
    Reserved,
    Ready,
    InProgress,
    Completed,
    Cancelled,
    Failed
}