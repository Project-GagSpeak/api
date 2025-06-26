using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated Restriction Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateRestriction(UserData User, UserData Enactor, ActiveRestriction NewData, DataUpdateType Type) : KinksterBase(User)
{
    public int AffectedLayer { get; init; } = -1;
    public Guid PreviousRestriction { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}
