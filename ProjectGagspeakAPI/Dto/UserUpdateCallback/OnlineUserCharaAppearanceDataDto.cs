using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updated to a pair or self's Appearance data.
/// <para><b>User == The user Updated (can be client caller or other pair)</b></para>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaAppearanceDataDto(UserData User, UserData Enactor, CharaAppearanceData AppearanceData, 
    GagLayer UpdatedLayer, GagUpdateType Type, Padlocks PreviousPadlock) : UserDto(User)
{
    [IgnoreMember]
    public bool IsFromSelf => User.UID == Enactor.UID;
}
