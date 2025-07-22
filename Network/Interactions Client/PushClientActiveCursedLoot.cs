using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Sends the new list of cursed <paramref name="ActiveItems"/> for the client to their Kinkster pairs,
///     including the <paramref name="ChangeItem"/> that was applied or removed.
/// </summary>
/// <remarks> If <paramref name="LootItem"/> is null, the item was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveLoot(List<UserData> Recipients, List<Guid> ActiveItems, Guid ChangeItem, AppliedItem? LootItem);

/// <summary>
///     When a Cursed Loot Item is modified, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangeLoot(List<UserData> Recipients, Guid Id, LightCursedLoot? LightItem);


/// <summary> Smol record detailing an applied cursed item. </summary>
public record AppliedItem(DateTimeOffset ReleaseTimeUTC, CursedLootType Type, Guid? RefId = null, GagType? Gag = null);