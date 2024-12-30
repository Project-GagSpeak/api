using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// The record containing the full kinkplate data.
/// Used when fetching KinkPlate Information via getters / func returns.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserKinkPlateDto(UserData User, KinkPlateContent Info, string? ProfilePictureBase64) : UserDto(User);

/// <summary>
/// The record containing the generic content of the kinkplate.
/// Used for updating the contents only, without the base64 image.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserKinkPlateContentDto(UserData User, KinkPlateContent Info) : UserDto(User);

/// <summary>
/// The record containing the generic content of the kinkplate.
/// Used for updating the image only.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserKinkPlatePictureDto(UserData User, string ProfilePictureBase64) : UserDto(User);
