using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated CursedLoot Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateCursedLoot(UserData User, IEnumerable<Guid> ActiveItems, LightCursedItem InteractedLoot) : KinksterBase(User);
