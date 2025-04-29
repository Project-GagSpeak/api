using GagspeakAPI.Data;
using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary> The information sent to a client whenever they successfully connect to GagSpeak Servers. </summary>
/// <remarks> All Synced Data Information is provided here. The client is responsible for keeping it synced. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionDto(UserData User, bool IsVerified)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }

    public UserGlobalPermissions GlobalPerms { get; init; } = new();
    public CharaActiveGags SyncedGagData { get; init; } = new();
    public CharaActiveRestrictions SyncedRestrictionsData { get; init; } = new();
    public CharaActiveRestraint SyncedRestraintSetData { get; init; } = new();
    public List<PublishedPattern> PublishedPatterns { get; init; } = new();
    public List<PublishedMoodle> PublishedMoodles { get; init; } = new();

    public List<string> ActiveAccountUidList { get; init; } = new(); // All Auth Uids associated with the connected user.
    public string UserAchievements { get; set; } = string.Empty; // Base64 string of the achievement data
}
