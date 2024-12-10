namespace GagspeakAPI.Enums;

public enum ResultFilter
{
    Downloads,
    Likes,
    DatePosted,
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

public enum SearchSort
{
    Ascending,
    Descending,
}

public enum SupportedTypes
{
    Vibration,
    Rotation,
}
