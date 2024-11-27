using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;


/// <summary>
/// Updates other users with the User's latest Storage Data information.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserStorageUpdateDto(UserData User, UserData Enactor, CharaStorageData LightStorage) : UserDto(User)
{
    [IgnoreMember]
    public bool IsFromSelf => User.UID == Enactor.UID;
}
