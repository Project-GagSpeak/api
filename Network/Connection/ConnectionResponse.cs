using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The data send to a client that just successfully connected to GagSpeak servers.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ConnectionResponse(UserData User, List<string> AccountProfileUids) : KinksterBase(User)
{
    public Version CurrentClientVersion { get; set; } = new(0, 0, 0);
    public int ServerVersion { get; set; }

    // The Reputation Standing for this Kinkster's Account.
    public UserReputation Reputation { get; set; } = new();

    // Personal Global Data (Active States, Achievements, ext)
    public GlobalPerms GlobalPerms { get; init; } = new();
    public HardcoreStatus HardcoreState { get; init; } = new();
    public CharaActiveGags GagData { get; init; } = new();
    public CharaActiveRestrictions RestrictionsData { get; init; } = new();
    public CharaActiveRestraint RestraintSetData { get; init; } = new();
    public CharaActiveCollar CollarData { get; init; } = new();

    // Base64 encoded string of the user's achievement data for quick loading.
    public string UserAchievements { get; set; } = string.Empty;
}

/// <summary> 
///     Initial Data to retrieve from the ShareHubs upon initial connection. <para />
///     (helps avoid excess server calls, only performing when necessary)
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record LobbyAndHubInfoResponse(List<string> HubTags)
{
    public List<PublishedPattern> PublishedPatterns { get; init; } = [];
    public List<PublishedMoodle> PublishedMoodles { get; init; } = [];
    public List<RoomInvite> RoomInvites { get; init; } = [];
}
