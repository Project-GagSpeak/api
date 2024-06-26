namespace GagSpeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the toybox module unique to each paired user.
/// </summary>
public class UserPermissionsWardrobe
{
    public bool ApplyRestraintSets { get; set; } // if the client pair can apply your restraint sets.
    public bool LockRestraintSets { get; set; }  // if the client pair can lock your restraint sets
    public TimeSpan MaxAllowedRestraintTime { get; set; } // the max time the client pair can lock your restraint sets
    public bool RemoveRestraintSets { get; set; } // if the client pair can remove your restraint sets.
}