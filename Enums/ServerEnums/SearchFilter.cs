namespace GagspeakAPI.Enums;

public enum HubFilter
{
    Downloads,
    Likes,
    DatePosted,
    LobbySize,
}

public enum DurationLength
{
    Any, // Any damn length
    Tiny, // under a minute
    Short, // 5 minutes or less
    Medium, // 5 to 20 minutes
    Long, // under an hour
    ExtraLong, // over an hour
}

public enum HubDirection
{
    Ascending,
    Descending,
}
