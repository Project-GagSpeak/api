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
public record UserPairDto(UserData User, 
    IndividualPairStatus IndividualPairStatus,
    UserPairPermissions OwnPairPerms, 
    UserEditAccessPermissions OwnEditAccessPerms, 
    UserGlobalPermissions OtherGlobalPerms, 
    UserPairPermissions OtherPairPerms, 
    UserEditAccessPermissions OtherEditAccessPerms) : UserDto(User)
{
    public IndividualPairStatus IndividualPairStatus { get; set; } = IndividualPairStatus;
    public UserPairPermissions OwnPairPerms { get; set; } = OwnPairPerms;
    public UserEditAccessPermissions OwnEditAccessPerms { get; set; } = OwnEditAccessPerms;
    public UserGlobalPermissions OtherGlobalPerms { get; set; } = OtherGlobalPerms;
    public UserPairPermissions OtherPairPerms { get; set; } = OtherPairPerms;
    public UserEditAccessPermissions OtherEditAccessPerms { get; set; } = OtherEditAccessPerms;
}
