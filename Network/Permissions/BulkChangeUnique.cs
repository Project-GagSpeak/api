using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Updates all PairPerms and UserPairPermissionAccess for
///     the <paramref name="User"/>'s end, to the new permissions.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeUnique(UserData User, PairPerms NewPerms, PairPermAccess NewAccess, UpdateDir Direction, UserData Enactor) : KinksterBase(User);
