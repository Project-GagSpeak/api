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

    public bool ProfileViewing { get; set; } = true;
    public DateTime ProfileViewTimeout { get; set; } = DateTime.MinValue;
    public int ProfileViewStrikes { get; set; } = 0;

    public bool ProfileEditing { get; set; } = true;
    public DateTime ProfileEditTimeout { get; set; } = DateTime.MinValue;
    public int ProfileEditStrikes { get; set; } = 0;

    public bool ChatUsage { get; set; } = true;
    public DateTime ChatTimeout { get; set; } = DateTime.MinValue;
    public int ChatStrikes { get; set; } = 0;

    public int FalseReportStrikes { get; set; } = 0;

    public int TotalStrikes() => ProfileViewStrikes + ProfileEditStrikes + ChatStrikes;

    public bool CanViewProfiles()
        => !IsBanned && ProfileViewing && DateTime.UtcNow >= ProfileViewTimeout;

    public bool CanEditProfile()
        => !IsBanned && ProfileEditing && DateTime.UtcNow >= ProfileEditTimeout;

    public bool CanUseChat()
        => !IsBanned && ChatUsage && DateTime.UtcNow >= ChatTimeout;
}
