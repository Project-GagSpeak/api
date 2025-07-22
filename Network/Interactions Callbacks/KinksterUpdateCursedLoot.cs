using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Callback informing the client of the Kinkster <paramref name="User"/>'s latest <paramref name="ActiveItems"/>,
///     providing the <paramref name="ChangedItem"/> indicating which item was applied or removed.
/// </summary>
/// <remarks> If <paramref name="ChangedItem"/> is not in <paramref name="ActiveItems"/>, it was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveCursedLoot(UserData User, List<Guid> ActiveItems, Guid ChangedItem) : KinksterBase(User);

/// <summary>
///     Callback informing a Cursed Loot's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
public record KinksterNewLootData(UserData User, Guid ItemId, LightCursedLoot? LightItem) : KinksterBase(User);

