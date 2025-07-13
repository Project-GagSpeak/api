using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated CursedLoot Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateCursedLoot(UserData User, List<Guid> ActiveItems, LightCursedItem InteractedLoot) : KinksterBase(User);
