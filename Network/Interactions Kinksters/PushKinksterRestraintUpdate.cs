using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///    The Updated RestraintSet Data for a Kinkster Pair, that will be sent to all pairs.
/// </summary>
/// <param name="Target"> The Kinkster that the update is for. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterRestraintUpdate(UserData Target, DataUpdateType Type) : KinksterBase(Target), IPadlockable
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public RestraintLayer ActiveLayers { get; init; } = RestraintLayer.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}

