using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Contains the information for all permissions you have for a pair, and that the pair has for you.
/// </summary>
/// <remarks>
///     Usually only fully assigned on connection, and after that updated individually,
///     hense the internal variables with setters.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterPair(UserData User, UserPairPermissions OwnPerms, UserEditAccessPermissions OwnAccess,
    UserGlobalPermissions Globals, UserPairPermissions Perms, UserEditAccessPermissions Access) : KinksterBase(User)
{
    // Perms the Client has for this Kinkster
    public UserPairPermissions OwnPerms { get; set; } = OwnPerms;
    public UserEditAccessPermissions OwnAccess { get; set; } = OwnAccess;

    // Permissions this Kinkster has for the Client
    public UserGlobalPermissions Globals { get; set; } = Globals;
    public UserPairPermissions Perms { get; set; } = Perms;
    public UserEditAccessPermissions Access { get; set; } = Access;
}
