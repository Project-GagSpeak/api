using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;


/// <summary>
/// Updates other users with the User's latest Storage Data information.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserStorageUpdateDto(UserData User, UserData Enactor, CharaStorageData LightStorage, UpdateDir Direction) : UserDto(User);
