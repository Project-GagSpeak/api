using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Data pushed by the client for a Global Alias Trigger that was modified, created, or deleted.
///     Then, syncs this change with the <paramref name="Recipient"/> kinkster.
/// </summary>
/// <remarks> If <paramref name="NewData"/> is null, implies the <paramref name="AliasId"/> was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientAliasUniqueUpdate(UserData Recipient, Guid AliasId, AliasTrigger? NewData) : KinksterBase(Recipient);
