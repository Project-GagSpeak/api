using Gagspeak.API.Data;
using Gagspeak.API.Data.Enum;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Data.Permissions;
using MessagePack;

namespace GagSpeak.API.Dto.UserPair;

/// <summary>
/// Contains the record DTO for a userpair of the client.
/// 
/// <para>
/// 
/// Clients global permissions are not stored on initialization as they are not needed
/// and are stored in the player character manager.
/// 
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairDto(UserData User, IndividualPairStatus IndividualPairStatus,
    UserPairPermissions ownPairPerms, UserEditAccessPermissions ownEditAccessPerms, UserGlobalPermissions otherGlobalPerms, 
    UserPairPermissions otherPairPerms, UserEditAccessPermissions otherEditAccessPerms) : UserDto(User)
{
    public UserPairPermissions OwnPairPerms { get; set; } = ownPairPerms;
    public UserEditAccessPermissions OwnEditAccessPerms { get; set; } = ownEditAccessPerms;
    public UserGlobalPermissions OtherGlobalPerms { get; set; } = otherGlobalPerms;
    public UserPairPermissions OtherPairPerms { get; set; } = otherPairPerms;
    public UserEditAccessPermissions OtherEditAccessPerms { get; set; } = otherEditAccessPerms;
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
}
