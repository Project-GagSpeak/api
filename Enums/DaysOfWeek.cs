namespace GagspeakAPI.Enums;

/// <summary> A Flag-Based structure of System.DayOfWeek </summary>
[Flags]
public enum DaysOfWeek
{
    None =           0,
    Sunday =    1 << 0,
    Monday =    1 << 1,
    Tuesday =   1 << 2,
    Wednesday = 1 << 3,
    Thursday =  1 << 4,
    Friday =    1 << 5,
    Saturday =  1 << 6,
}

public static class FlagEnumEx
{
    public static string ToShortName(this DaysOfWeek day)
        => day switch
        {
            DaysOfWeek.Sunday    => "Sun",
            DaysOfWeek.Monday    => "Mon",
            DaysOfWeek.Tuesday   => "Tue",
            DaysOfWeek.Wednesday => "Wed",
            DaysOfWeek.Thursday  => "Thu",
            DaysOfWeek.Friday    => "Fri",
            DaysOfWeek.Saturday  => "Sat",
            _ => "None",
        };

    /// <summary> Converts System.DayOfWeek to the DaysOfWeek flag variant. </summary>
    public static DaysOfWeek ToFlagVariant(this DayOfWeek day)
        => (DaysOfWeek)(1 << (int)day);

    /// <summary> Converts a DaysOfWeek flag to System.DayOfWeek. </summary>
    /// <remarks> Only takes the first matching flag, and ignores the rest. </remarks>
    public static DayOfWeek ToDayOfWeek(this DaysOfWeek flag)
    {
        return flag switch
        {
            DaysOfWeek.Sunday => DayOfWeek.Sunday,
            DaysOfWeek.Monday => DayOfWeek.Monday,
            DaysOfWeek.Tuesday => DayOfWeek.Tuesday,
            DaysOfWeek.Wednesday => DayOfWeek.Wednesday,
            DaysOfWeek.Thursday => DayOfWeek.Thursday,
            DaysOfWeek.Friday => DayOfWeek.Friday,
            DaysOfWeek.Saturday => DayOfWeek.Saturday,
            _ => throw new ArgumentException($"'{flag}' is not a single valid day flag."),
        };
    }
}
