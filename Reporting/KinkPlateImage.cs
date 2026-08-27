using GagspeakAPI.Data;
using GagspeakAPI.User;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///   Contains a KinkPlate's Profile Image datastring.
/// </summary>
/// <remarks>
///   Used for updating the image only.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinkPlateImage(UserData User, string ImageBase64) : UserDto(User);
