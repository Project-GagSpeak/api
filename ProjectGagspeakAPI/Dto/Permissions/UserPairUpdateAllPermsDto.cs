using Gagspeak.API.Data;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Data.Permissions;
using MessagePack;

namespace GagSpeak.API.Dto.Permissions;

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