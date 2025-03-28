using GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto;

/// <summary> The Data storing the compressed string of achievement data from the user. </summary>
/// <param name="AchievementDataBase64">The base64 string (compressed) of the achievement data.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserAchievementsDto(UserData User, string? AchievementDataBase64) : UserDto(User);
