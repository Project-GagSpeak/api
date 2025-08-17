using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated Collar Data of a specified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveCollar(UserData User, UserData Enactor, CharaActiveCollar NewData, DataUpdateType Type) : KinksterBase(User)
{
    public Guid PreviousCollar { get; init; } = Guid.Empty;
}

/// <summary>
///     Callback informing a Collar's data was updated for a specific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterNewCollarData(UserData User, Guid ItemId, LightCollar? LightItem) : KinksterBase(User);