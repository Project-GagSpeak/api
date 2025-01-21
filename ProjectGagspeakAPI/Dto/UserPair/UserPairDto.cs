using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.UserPair;

/// <summary> 
/// Contains the record DTO for a userpair of the client.
/// <para>
/// Clients global permissions are not stored on initialization as they are not needed
/// and are stored in the player character manager.
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User,
    UserPairPermissions OwnPairPerms,
    UserEditAccessPermissions OwnEditAccessPerms,
    UserGlobalPermissions OtherGlobalPerms,
    UserPairPermissions OtherPairPerms,
    UserEditAccessPermissions OtherEditAccessPerms) : UserDto(User)
{
    public UserPairPermissions OwnPairPerms { get; set; } = OwnPairPerms;
    public UserEditAccessPermissions OwnEditAccessPerms { get; set; } = OwnEditAccessPerms;
    public UserGlobalPermissions OtherGlobalPerms { get; set; } = OtherGlobalPerms;
    public UserPairPermissions OtherPairPerms { get; set; } = OtherPairPerms;
    public UserEditAccessPermissions OtherEditAccessPerms { get; set; } = OtherEditAccessPerms;
}
