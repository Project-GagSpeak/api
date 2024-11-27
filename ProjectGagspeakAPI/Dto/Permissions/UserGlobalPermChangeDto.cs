using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// DTO responsible for transferring the a user's UID from the users table in the DB.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserGlobalPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission) : UserDto(User)
{
    [IgnoreMember]
    public bool IsFromSelf => User.UID == Enactor.UID;
}