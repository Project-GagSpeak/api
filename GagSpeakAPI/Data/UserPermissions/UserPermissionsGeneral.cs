namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsGeneral
{
    public bool ExtendedLockTimes { get; set; }  // if user allowed extended lock times for this paired user
    public TimeSpan MaxLockTime { get; set; }    // the max lock time for this paired user
    public bool InHardcore { get; set; }         // if the user is in hardcore mode with this paired user
}