using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated RestraintSet Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveRestraint(List<UserData> Recipients, DataUpdateType Type)
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public RestraintLayer ActiveLayers { get; init; } = RestraintLayer.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

/// <summary>
///     When a Restraint Set is created, modified, or removed, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangeRestraint(List<UserData> Recipients, Guid ItemId, LightRestraint? LightItem);
