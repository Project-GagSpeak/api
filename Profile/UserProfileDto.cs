using GagspeakAPI.User;
using MessagePack;

namespace GagspeakAPI.Profiles;

/// <summary> A Users full profile data </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileData(UserData User, UserProfileInfo Info, ProfileImages Images) : UserDto(User);

/// <summary> The contents of a users profile, excluding the image data. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UserProfileInfo(bool NsfwIcon, bool NsfwBg, bool NsfwDesc, bool Flagged, string ContentJson)
{
    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static UserProfileInfo Empty { get; } = new(false, false, false, false, string.Empty);
}

/// <summary> 
///   The base64 imagedata for a users profile. <br/>
///   If the value is null it indicates it is not being updated. <para/>
///   If the value is empty is is being cleared. <para/>
///   If the value is not empty, it is being updated.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ProfileImages(string? IconBase64, string? BackgroundBase64)
{
    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static ProfileImages Null { get; } = new(null, null);

    /// <summary> A default, empty profile state. Ignored during serialization. </summary>
    [IgnoreMember] public static ProfileImages Empty { get; } = new(string.Empty, string.Empty);

}