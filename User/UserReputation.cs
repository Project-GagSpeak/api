using MessagePack;

namespace GagspeakAPI.User;

/// <summary>
///   The primary record used to represent a Sundouleia user.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserReputation
{
    public bool IsVerified { get; set; } = false;
    public bool IsBanned { get; set; } = false;
    public int WarningStrikes { get; set; } = 0;

    // Reputation for viewing other profiles
    public bool     ProfileViewing { get; set; } = true;
    public DateTime ProfileViewTimeout { get; set; } = DateTime.MinValue;
    public int      ProfileViewStrikes { get; set; } = 0;

    // Reputation for customizing profiles.
    public bool     ProfileEditing { get; set; } = true;
    public DateTime ProfileEditTimeout { get; set; } = DateTime.MinValue;
    public int      ProfileEditStrikes { get; set; } = 0;

    // Reputation for Radar usage.
    public bool     RadarUsage { get; set; } = true;
    public DateTime RadarTimeout { get; set; } = DateTime.MinValue;
    public int      RadarStrikes { get; set; } = 0;

    // Reputation for Radar Chat usage.
    public bool     ChatUsage { get; set; } = true;
    public DateTime ChatTimeout { get; set; } = DateTime.MinValue;
    public int      ChatStrikes { get; set; } = 0;

    [IgnoreMember] public bool CanViewProfiles => ProfileViewing && ProfileViewTimeout < DateTime.UtcNow;
    [IgnoreMember] public bool CanEditProfiles => ProfileEditing && ProfileEditTimeout < DateTime.UtcNow;
    [IgnoreMember] public bool CanUseRadar => RadarUsage && RadarTimeout < DateTime.UtcNow;
    [IgnoreMember] public bool CanUseChat => ChatUsage && ChatTimeout < DateTime.UtcNow;
}
