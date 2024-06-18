using Gagspeak.API.Data;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// The Record DTo for the API of a User's profile popup.
/// </summary>
/// <param name="User">The UserData (UID) that this profile belongs to.</param>
/// <param name="Disabled">If the user has the profile disabled</param>
/// <param name="ProfilePictureBase64">The profile picture embedded in the profile</param>
/// <param name="Description">The description added in the profile</param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(UserData User, bool Disabled, string? ProfilePictureBase64, string? Description) : UserDto(User);
