using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Updates all Global-Related perms <paramref name="User"/> to their new values.
/// </summary>
/// <remarks>
///     If used in a callback, the <paramref name="User"/> is <u>the Kinkster that made the change</u>,
///     if used in a server call, <paramref name="User"/> is irrelevant, but should always be the caller.</u>.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record BulkChangeGlobal(UserData User, GlobalPerms NewPerms, HardcoreStatus NewState) : KinksterBase(User)
{
    public override string ToString() => $"BulkChangeGlobalPerms: [Target -> {User.AliasOrUID}]";
}

[MessagePackObject(keyAsPropertyName: true)]
public record ClientGlobals(GlobalPerms Globals, HardcoreStatus Hardcore);
