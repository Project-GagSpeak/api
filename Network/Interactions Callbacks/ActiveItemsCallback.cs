using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Composite Data of the <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster that the Composite Data is for. </param>
/// <param name="WasSafeword"> If this update was due to a safeword or not. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateComposite(UserData User, CharaCompositeActiveData Data, bool WasSafeword) : KinksterBase(User);

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
///     When a <paramref name="User"/>'s ActiveItem data changed with a <paramref name="Type"/> by <paramref name="Enactor"/>
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveRestriction(UserData User, UserData Enactor, ActiveRestriction NewData, DataUpdateType Type) : KinksterBase(User)
{
    public int AffectedLayer { get; init; } = -1;
    public Guid PreviousRestriction { get; init; } = Guid.Empty;
    public Padlocks PreviousPadlock { get; init; } = Padlocks.None;
}

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

[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateActiveCollar(UserData User, UserData Enactor, CharaActiveCollar NewData, DataUpdateType Type) : KinksterBase(User);

