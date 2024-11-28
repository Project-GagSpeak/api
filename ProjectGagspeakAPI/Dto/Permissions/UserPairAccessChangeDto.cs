using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// DTO responsible for transferring the a user's UID from the users table in the DB.
/// <para>
/// Could potentially transfer the vanity tier along inside the UserData if we need it later. 
/// We'll see.
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairAccessChangeDto(UserData User, UserData Enactor, KeyValuePair<string, object> ChangedAccessPermission, UpdateDir Direction) : UserDto(User);
