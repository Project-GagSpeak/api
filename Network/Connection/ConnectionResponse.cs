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

    public GlobalPerms GlobalPerms { get; init; } = new();
    public HardcoreState HardcoreState { get; init; } = new();
    public CharaActiveGags SyncedGagData { get; init; } = new();
    public CharaActiveRestrictions SyncedRestrictionsData { get; init; } = new();
    public CharaActiveRestraint SyncedRestraintSetData { get; init; } = new();
    public CharaActiveCollar SyncedCollarData { get; init; } = new();

    public List<string> ActiveAccountUidList { get; init; } = new();
    public string UserAchievements { get; set; } = string.Empty;
}

/// <summary> Initial Data to retrieve from the ShareHubs upon initial connection. </summary>
/// <remarks> This avoids excess server calls, and only performs them when necessary. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record LobbyAndHubInfoResponse(List<string> HubTags)
{
    public List<PublishedPattern> PublishedPatterns { get; init; } = [];
    public List<PublishedMoodle> PublishedMoodles { get; init; } = [];
    public List<RoomInvite> RoomInvites { get; init; } = [];
}
