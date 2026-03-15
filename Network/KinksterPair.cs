using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     A helper record for a return function on accepting a request, 
///     compiling the send online call and add pair call into one!
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AddedKinksterPair(KinksterPair Pair, OnlineKinkster? OnlineInfo);

/// <summary>
///     Holds all essential information of permissions and information between 2 paired kinksters.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterPair(UserData User, PairPerms OwnPerms, PairPermAccess OwnAccess,
    GlobalPerms Globals, HardcoreState Hardcore, PairPerms Perms, PairPermAccess Access, DateTime CreatedAt) : KinksterBase(User)
{
    // Perms the Client has for this Kinkster
    public PairPerms OwnPerms { get; set; } = OwnPerms;
    public PairPermAccess OwnAccess { get; set; } = OwnAccess;

    // Permissions this Kinkster has for the Client
    public GlobalPerms Globals { get; set; } = Globals;
    public HardcoreState Hardcore { get; set; } = Hardcore;
    public PairPerms Perms { get; set; } = Perms;
    public PairPermAccess Access { get; set; } = Access;
}
