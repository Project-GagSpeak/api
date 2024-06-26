using Gagspeak.API.Data;
using GagSpeak.API.Data.Character;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// Data Transfer Object record for an online user, with their character data attached.
/// </summary>
/// <param name="User"></param>
/// <param name="CharaData"></param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaDataDto(UserData User, CharacterCompositeData CharaData) : UserDto(User);