using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Performs an update to all 3 permission areas at once due to a safeword being performed. <para />
///     We should assume that upon recieving a callback of this, that all other active data is turned off and reset. <para />
///     If the <paramref name="SpesificKinkster"/> is not null, then the unique and access permissions are updated for all of the callers pairs.
///     Updates all permission sections for a <paramref name="User"/>, to the new permissions.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeAll(UserData User, GlobalPerms Globals, PairPerms Unique, PairPermAccess Access, UserData? SpesificKinkster) : KinksterBase(User);
