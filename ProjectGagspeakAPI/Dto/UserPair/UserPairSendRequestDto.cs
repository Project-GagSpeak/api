using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.UserPair;

/// <summary> Contains essential information about a Kinkster Request Entry between pairs. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserPairSendRequestDto(UserData User, string AttachedMessage) : UserDto(User);
