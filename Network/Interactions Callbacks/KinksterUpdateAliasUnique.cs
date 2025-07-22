using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     An update for <paramref name="User"/>, one of a Paired Kinksters Alias Data for the Client.
///     This is recieved whenever an Alias item is modified, created, or deleted, spesifically for this Kinkster Pair.
/// </summary>
/// <remarks> If <paramref name="NewData"/> is null, implies the <paramref name="AliasId"/> was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateAliasUnique(UserData User, Guid AliasId, AliasTrigger? NewData) : KinksterBase(User);

