using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     DTO Holding the Kinkster, and the desired achievement data string.
/// </summary>
/// <remarks>
///     The Data string is the compressed string of achievement data from the user.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record AchievementsUpdate(UserData User, string? AchievementDataBase64) : KinksterBase(User);
