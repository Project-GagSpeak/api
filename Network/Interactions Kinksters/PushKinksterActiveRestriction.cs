using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///    The Updated RestrictionItem Data for a Kinkster Pair, that will be sent to all pairs.
/// </summary>
/// <param name="Target"> The Kinkster that the update is for. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActiveRestriction(UserData Target, DataUpdateType Type) : KinksterBase(Target), IPadlockable
{
    public int Layer { get; init; } = -1;
    public Guid RestrictionId { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}
