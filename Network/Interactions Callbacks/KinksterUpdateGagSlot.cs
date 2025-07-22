using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated Gag Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveGag(UserData User, UserData Enactor, ActiveGagSlot NewData, DataUpdateType Type) : KinksterBase(User)
{
    public int AffectedLayer { get; init; } = -1;
    public GagType PreviousGag { get; init; } = GagType.None;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}

/// <summary>
///     Callback informing a Gag's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="GagType"/> defines what Gag changed. The item is the new data for it, 
///     or if null, indiciates what item to remove.
/// </summary>
public record KinksterNewGagData(UserData User, GagType GagType, LightGag? Item) : KinksterBase(User);
