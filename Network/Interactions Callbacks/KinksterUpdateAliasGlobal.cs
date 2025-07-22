using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     An update for <paramref name="User"/>, one of the client's Paired Kinksters Global Alias Data.
///     This is recieved whenever a Global Alias item is modified, created, or deleted.
/// </summary>
/// <remarks> If <paramref name="NewData"/> is null, implies the <paramref name="AliasId"/> was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateAliasGlobal(UserData User, Guid AliasId, AliasTrigger? NewData) : KinksterBase(User);
