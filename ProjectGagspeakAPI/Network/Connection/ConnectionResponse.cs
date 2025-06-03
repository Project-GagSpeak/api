using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The data send to a client that just successfully connected to GagSpeak servers.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionResponse(UserData User, bool Verified) : KinksterBase(User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }

    public UserGlobalPermissions GlobalPerms { get; init; } = new();
    public CharaActiveGags SyncedGagData { get; init; } = new();
    public CharaActiveRestrictions SyncedRestrictionsData { get; init; } = new();
    public CharaActiveRestraint SyncedRestraintSetData { get; init; } = new();
    public List<PublishedPattern> PublishedPatterns { get; init; } = new();
    public List<PublishedMoodle> PublishedMoodles { get; init; } = new();

    // All Auth Uids associated with the connected user.
    public List<string> ActiveAccountUidList { get; init; } = new();

    // Base64 string of the achievement data
    public string UserAchievements { get; set; } = string.Empty;
}
