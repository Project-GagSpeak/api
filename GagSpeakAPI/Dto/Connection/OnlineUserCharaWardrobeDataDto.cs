using Gagspeak.API.Data;
using Gagspeak.API.Dto.User;
using GagSpeak.API.Data.Character;
using MessagePack;

namespace GagSpeak.API.Dto.Connection;

/// <summary>
/// 
/// Data Transfer Object record for an online user, with their character data attached.
/// 
/// </summary>
/// <param name="User"> the user who just went online and is sending us their composite data </param>
/// <param name="CharaData"> the composite character data containing all components of a users characterdata</param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaWardrobeDataDto(UserData User, CharacterWardrobeData WardrobeData) : UserDto(User);