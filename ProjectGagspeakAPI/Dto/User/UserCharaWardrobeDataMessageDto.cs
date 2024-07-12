using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// Represents a message that contains the character data of a user, and the recipients that should recieve it
/// </summary>
/// <param name="Recipients">The list of client users that should recieve this data transfer object</param>
/// <param name="CharaData">Contains information related to the users permissions and settings.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaWardrobeDataMessageDto(List<UserData> Recipients, CharacterWardrobeData WardrobeData);
