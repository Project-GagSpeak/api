using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///    The Updated GagSlot Data for a Kinkster Pair, that will be sent to all pairs.
/// </summary>
/// <param name="Target"> The Kinkster that the update is for. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterActiveGagSlot(UserData Target, DataUpdateType Type) : KinksterBase(Target), IPadlockable
{
    public int Layer { get; init; } = -1;
    public GagType Gag { get; init; } = GagType.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string PadlockAssigner { get; init; } = string.Empty;
}
