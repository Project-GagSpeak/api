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
public record UserPairRequestDto(UserData User, UserData RecipientUser, string AttachedMessage, DateTime CreationTime) : UserDto(User)
{
    public bool isExpired() => DateTime.Now - CreationTime > TimeSpan.FromDays(3);
}
