namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsMoodles
{
    public bool AllowPositiveStatusTypes { get; set; } // if the client pair can give you positive moodles
    public bool AllowNegativeStatusTypes { get; set; } // if the client pair can give you negative moodles
    public bool AllowSpecialStatusTypes { get; set; }  // if the client pair can give you neutral moodles
    public bool PairCanApplyOwnMoodlesToYou { get; set; } // if the client pair can apply their moodles to you
    public bool PairCanApplyYourMoodlesToYou { get; set; } // if the client pair can apply your moodles
    public TimeSpan MaxMoodleTime { get; set; } // the max time the client pair can apply moodles to you
    public bool AllowPermanentMoodles { get; set; } // if the client pair can apply permanent moodles to you
}