using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updating the shock permissions. Can be global, ownPair, or otherPair.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaPiShockPermDto(UserData User, PiShockPermissions shockPerms, DataUpdateKind UpdateKind) : UserDto(User);
