using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updated to a pair or self's Wardrobe data
/// </summary>
/// <param name="User"> The User that will be affected by this change.</param>
/// <param name="WardrobeData"> The updated wardrobe data.</param>
/// <param name="Enactor"> The user that initiated this change.</param>
/// <param name="Type"> The kind of update this change makes.</param>
/// <param name="PreviousLock"> The previous lock state of the wardrobe.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaWardrobeDataDto(UserData User, UserData Enactor, CharaWardrobeData WardrobeData, 
    WardrobeUpdateType Type, Padlocks PreviousLock, UpdateDir Direction) : UserDto(User);
