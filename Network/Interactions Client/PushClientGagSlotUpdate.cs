using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated GagSlot Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientGagSlotUpdate(List<UserData> Recipients, DataUpdateType Type)
{
    // Any of these are only set if they are the new change.
    public int Layer { get; init; } = -1;
    public GagType Gag { get; init; } = GagType.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}
