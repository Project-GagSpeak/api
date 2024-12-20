using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.Permissions;
using MessagePack;

namespace GagspeakAPI.Dto.UserPair;

/// <summary>
/// Contains essential information about a Kinkster Request Entry between pairs.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairSendRequestDto(UserData User, string AttachedMessage) : UserDto(User);