using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary> The information sent to a client whenever they successfully connect to GagSpeak Servers. </summary>
/// <remarks> All Synced Data Information is provided here. The client is responsible for keeping it synced. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionDto(UserData User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }

    public UserGlobalPermissions GlobalPerms { get; init; } = new();
    public CharaActiveGags SyncedGagData { get; init; } = new();
    public CharaActiveRestrictions SyncedRestrictionsData { get; init; } = new();
    public CharaActiveRestraint SyncedRestraintSetData { get; init; } = new();
    public List<PublishedPattern> PublishedPatterns { get; init; } = new();
    public List<PublishedMoodle> PublishedMoodles { get; init; } = new();

    /// <summary> Helps us know when an account was removed via discord. </summary>
    public List<string> ActiveAccountUidList { get; init; } = new();

    /// <summary> Base64 Achievement Data string stored on the server. </summary>
    public string UserAchievements { get; set; } = string.Empty;
}
