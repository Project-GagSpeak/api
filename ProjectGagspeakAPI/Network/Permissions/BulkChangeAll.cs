using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Updates all permission sections for a <paramref name="User"/>, to the new permissions.
/// </summary>
/// <remarks>
///     If used in a callback, the <paramref name="User"/> is <u>the Kinkster that made the change</u>,
///     if used in a server call, <paramref name="User"/> is <u>the target Kinkster to make the changes to</u>.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeAll(UserData User, UserGlobalPermissions Globals, UserPairPermissions Unique,
    UserEditAccessPermissions Access) : KinksterBase(User);
