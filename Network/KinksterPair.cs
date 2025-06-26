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
public record KinksterPair(UserData User, PairPerms OwnPerms, PairPermAccess OwnAccess,
    GlobalPerms Globals, PairPerms Perms, PairPermAccess Access) : KinksterBase(User)
{
    // Perms the Client has for this Kinkster
    public PairPerms OwnPerms { get; set; } = OwnPerms;
    public PairPermAccess OwnAccess { get; set; } = OwnAccess;

    // Permissions this Kinkster has for the Client
    public GlobalPerms Globals { get; set; } = Globals;
    public PairPerms Perms { get; set; } = Perms;
    public PairPermAccess Access { get; set; } = Access;
}
