using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.User;

/// <summary>
/// DTO for handling the updating of our own data to our online user pairs.
/// </summary>
/// <param name="Recipients">The recipients of the update.</param>
/// <param name="OrdersData">the orders info to update.</param>
/// <param name="Type">What kind of update interaction is occuring.</param>
/// <param name="AffectedItem">The item that was affected when the change was made, if any (may not even be needed).</param>
[MessagePackObject(keyAsPropertyName: true)]
public record UserCharaOrdersDataMessageDto(
    List<UserData> Recipients, CharaOrdersData OrdersData, OrdersUpdateType Type, string AffectedItem);
