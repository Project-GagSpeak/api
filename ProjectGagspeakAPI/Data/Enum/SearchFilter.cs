// Search filter used for patterns.
namespace GagspeakAPI.Data.Enum;
public enum SearchFilter
{
    MostRecent,
    Downloads,
    Likes,
    Author,
    DurationTiny, // under a minute
    DurationShort, // 5 minutes or less
    DurationMedium, // 5 to 20 minutes
    DurationLong, // under an hour
    DurationExtraLong, // over an hour
    UsesVibration,
    UsesRotation,
    UsesOscillation,
}

public enum SearchSort
{
    Ascending,
    Descending,
}
