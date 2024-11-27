using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// DTO responsible for transferring the a user's UID from the users table in the DB.
/// </summary>
/// <param name="User"> The user who is having their permission modified </param>
/// <param name="ChangedPermission"> nameof(permission name) permission being changed to (object) new value </param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairPermChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedPermission) : UserDto(User)
{
    [IgnoreMember]
    public bool IsFromSelf => User.UID == Enactor.UID;
}