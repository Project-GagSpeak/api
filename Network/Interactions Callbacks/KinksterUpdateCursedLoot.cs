using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated CursedLoot Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveCursedLoot(UserData User, List<Guid> LatestActiveItems) : KinksterBase(User);

/// <summary>
///     Callback informing a Cursed Loot's data was updated for a spesific <paramref name="User"/>. <para />
///     The <paramref name="ItemId"/> defines what item changed, with <paramref name="LightItem"/>
///     holding its data. If null, the callback implies this Item should be removed from the kinkster cache.
/// </summary>
public record KinksterNewLootData(UserData User, Guid ItemId, LightCursedLoot? LightItem) : KinksterBase(User);
