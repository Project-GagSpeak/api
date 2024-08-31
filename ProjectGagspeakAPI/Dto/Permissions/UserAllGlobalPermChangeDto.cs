using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.Permissions;

/// <summary> 
/// Update all global permissions of a player.
/// Only made for server callbacks, not used in any server calls.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserAllGlobalPermChangeDto(UserData User, UserGlobalPermissions GlobalPermissions) : UserDto(User);
