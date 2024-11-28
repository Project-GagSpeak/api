using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// ONLY CALLED BY SELF
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairUpdateAllGlobalPermsDto(UserData User, UserData Enactor, UserGlobalPermissions GlobalPermissions, UpdateDir Direction) : UserDto(User);
