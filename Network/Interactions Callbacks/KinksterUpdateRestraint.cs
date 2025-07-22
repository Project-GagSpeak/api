using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated Restraint Set Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveRestraint(UserData User, UserData Enactor, CharaActiveRestraint NewData, DataUpdateType Type) : KinksterBase(User)
{
    public Guid PreviousRestraint { get; init; } = Guid.Empty;
    public RestraintLayer PrevLayers { get; init; } = RestraintLayer.None;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}

/// <summary>
///     Callback informing a Restraints's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
public record KinksterNewRestraintData(UserData User, Guid ItemId, LightRestraint? LightItem) : KinksterBase(User);
