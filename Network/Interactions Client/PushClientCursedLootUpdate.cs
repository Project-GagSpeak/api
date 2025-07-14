using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated CursedLoot Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="ActiveItems"> the ID's of the currently active cursed loot. </param>
/// <param name="InteractedLoot"> The cursed loot the client interacted with that caused the update. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientCursedLootUpdate(List<UserData> Recipients, List<Guid> ActiveItems, LightCursedItem InteractedLoot);
