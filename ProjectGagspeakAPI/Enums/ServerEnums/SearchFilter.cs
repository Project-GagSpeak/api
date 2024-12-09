namespace GagspeakAPI.Enums;

public enum ResultFilter
{
    Downloads,
    Likes,
    MostRecent,
}

public enum DurationLength
{
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
