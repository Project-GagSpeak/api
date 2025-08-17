using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Collar Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveCollar(List<UserData> Recipients, DataUpdateType Type)
{
    public Guid CollarId { get; init; } = Guid.Empty;
    public List<string> OwnerUIDs { get; init; } = new List<string>();
    public byte Dye1 { get; init; } = 0;
    public byte Dye2 { get; init; } = 0;
    public MoodlesStatusInfo Moodle { get; init; } = new();
    public string Writing { get; init; } = string.Empty;
    // Move these to respective global/kinkster pair permission tables if it is easier there.
    public CollarAccess EditAccess { get; init; } = CollarAccess.None;
    public CollarAccess OwnerEditAccess { get; init; } = CollarAccess.None;
}

/// <summary>
///     When a Collar is created, modified, or removed, push its new data to the 
///     <paramref name="Recipients"/> for caching. <para />
///     
///     If <paramref name="LightItem"/> is null, it is assumed the item is to be removed. <para />
///     
///     Because the Collar's Data is mostly reflected in its active state, little is changed here.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientDataChangeCollar(List<UserData> Recipients, Guid ItemId, LightCollar? LightItem);
