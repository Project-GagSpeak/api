using Gagspeak.API.Data;
using MessagePack;

namespace Gagspeak.API.Dto.User;

/// <summary>
/// a datatransfer object that stores the information for the mini-profile window of a user.
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileDto(
    UserData User,                      // the user of whom the profile belongs to
    bool Disabled,                      // if they have their profile disabled
    string? ProfilePictureBase64,       // the base64 string of the profile picture
    string? Description                 // the description the user has set for their profile image
    ) : UserDto(User);                  // inherit the user data ( which is already defined above??? )