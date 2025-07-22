using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> The Updated CursedLoot Data for the client, that will be sent to all kinksters. </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="ActiveItems"> the ID's of the currently active cursed loot. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveLoot(List<UserData> Recipients, List<Guid> ActiveItems);

/// <summary>
///     When a Cursed Loot Item is modified, push its new data to the <paramref name="Recipients"/> 
///     for caching. If <paramref name="LightItem"/> is null, it is assumed the item is to be removed.
/// </summary>
public record PushClientDataChangeLoot(List<UserData> Recipients, Guid Id, LightCursedLoot? LightItem);
