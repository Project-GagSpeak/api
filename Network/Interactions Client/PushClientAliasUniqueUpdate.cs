using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Unique Alias Data for a modified, created, or deleted Alias Item, sent out to all pairs.
/// </summary>
/// <param name="Recipient"> the Kinkster this unique alias was for. </param>
/// <param name="Alias"> The Alias item affected.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientAliasUniqueUpdate(UserData Recipient, AliasTrigger Alias) : KinksterBase(Recipient);
