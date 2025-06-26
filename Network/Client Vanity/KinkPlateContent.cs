using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Contains the generic content of the KinkPlate.
/// </summary>
/// <remarks>
///     Used for updating the contents only, without the base64 image.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinkPlateInfo(UserData User, KinkPlateContent Info) : KinksterBase(User);
