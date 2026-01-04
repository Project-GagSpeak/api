using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
///     The primary record used to represent a Sundouleia user.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserReputation
{
    public bool IsVerified { get; set; } = false;
    public bool IsBanned { get; set; } = false;
    public int WarningStrikes { get; set; } = 0;

    public bool ProfileViewing { get; set; } = true;
    public int ProfileViewStrikes { get; set; } = 0;

    public bool ProfileEditing { get; set; } = true;
    public int ProfileEditStrikes { get; set; } = 0;

    public bool ChatUsage { get; set; } = true;
    public int ChatStrikes { get; set; } = 0;

    public int TotalStrikes() => WarningStrikes + ProfileViewStrikes + ProfileEditStrikes + ChatStrikes;
}
