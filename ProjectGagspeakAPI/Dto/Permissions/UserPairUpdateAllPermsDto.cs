using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// 
/// DTO responsible for transferring the a user's UID from the users table in the DB.
/// 
/// <para>
/// 
/// Could potentially transfer the vanity tier along inside the UserData if we need it later. 
/// We'll see.
/// 
/// </para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairUpdateAllPermsDto(
    UserData User, 
    UserGlobalPermissions GlobalPermissions,
    UserPairPermissions PairPermissions,
    UserEditAccessPermissions EditAccessPermissions    
    )
    : UserDto(User);