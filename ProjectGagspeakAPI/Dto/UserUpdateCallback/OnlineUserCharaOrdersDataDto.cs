using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using GagspeakAPI.Dto.User;
using MessagePack;

namespace GagspeakAPI.Dto.Connection;

/// <summary>
/// DTO for handling updated to a pair or self's orders data.
/// </summary>
/// <param name="User"> The User that will be affected by this change.</param>
/// <param name="Enactor"> The user that initiated this change.</param>
/// <param name="OrdersData"> The updated orders data.</param>
/// <param name="Type"> The kind of update this change makes.</param>
/// <param name="AffectedId">The GUID affected by this change.</param>
[MessagePackObject(keyAsPropertyName: true)]
public record OnlineUserCharaOrdersDataDto(UserData User, UserData Enactor, 
    CharaOrdersData OrdersData, OrdersUpdateType Type, string AffectedItem, UpdateDir Direction) : UserDto(User);
