using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Global Alias Data for a modified, created, or deleted Alias Item, sent out to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="Alias"> The Alias item affected.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientAliasGlobalUpdate(List<UserData> Recipients, AliasTrigger Alias);
