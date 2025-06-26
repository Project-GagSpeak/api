using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Contains the full KinkPlate data. Content and Image both.
/// </summary>
/// <remarks>
///     Used when fetching KinkPlate Information via getters / func returns.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinkPlateFull(UserData User, KinkPlateContent Info, string? ImageBase64) : KinksterBase(User);
