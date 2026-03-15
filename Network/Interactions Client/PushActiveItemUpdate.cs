using GagspeakAPI.Attributes;
using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated GagSlot Data for the client, sent to all <paramref name="Recipients"/>
/// </summary>
/// <param name="Recipients"> the Client's pairs. </param>
/// <param name="Type"> The type of update that was made. </param> 
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveGagSlot(List<UserData> Recipients, DataUpdateType Type)
{
    // Any of these are only set if they are the new change.
    public int Layer { get; init; } = -1;
    public GagType Gag { get; init; } = GagType.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

/// <summary>
///     New ActiveRestrictionData for the client, sent to all <paramref name="Recipients"/>
/// </summary>
/// <param name="Recipients"> the Client's pairs. </param>
/// <param name="Type"> The type of update that was made. </param> 
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveRestriction(List<UserData> Recipients, DataUpdateType Type)
{
    public int Layer { get; init; } = -1;
    public Guid Identifier { get; init; } = Guid.Empty;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

/// <summary>
///     New ActiveRestrictionData for the client, sent to all <paramref name="Recipients"/>
/// </summary>
/// <param name="Recipients"> the Client's pairs. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveRestraint(List<UserData> Recipients, DataUpdateType Type)
{
    public Guid ActiveSetId { get; init; } = Guid.Empty;
    public RestraintLayer ActiveLayers { get; init; } = RestraintLayer.None;
    public string Enabler { get; init; } = string.Empty;
    public Padlocks Padlock { get; init; } = Padlocks.None;
    public string Password { get; init; } = string.Empty;
    public DateTimeOffset Timer { get; init; } = DateTimeOffset.MinValue;
    public string Assigner { get; init; } = string.Empty;
}

/// <summary>
///     The Updated Collar Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveCollar(List<UserData> Recipients, DataUpdateType Type)
{
    public bool Applied { get; init; } = false;
    public List<string> OwnerUIDs { get; init; } = new List<string>();
    public bool Visuals { get; init; } = false;
    public byte Dye1 { get; init; } = 0;
    public byte Dye2 { get; init; } = 0;
    public LociStatusStruct StatusInfo { get; init; } = new();
    public string Writing { get; init; } = string.Empty;
    // Move these to respective global/kinkster pair permission tables if it is easier there.
    public CollarAccess EditAccess { get; init; } = CollarAccess.None;
    public CollarAccess OwnerEditAccess { get; init; } = CollarAccess.None;
}


/// <summary>
///     Sends the new list of cursed <paramref name="ActiveItems"/> for the client to their Kinkster pairs,
///     including the <paramref name="ChangeItem"/> that was applied or removed.
/// </summary>
/// <remarks> If <paramref name="LootItem"/> is null, the item was removed. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientActiveLoot(List<UserData> Recipients, List<Guid> ActiveItems, Guid ChangeItem, AppliedItem? LootItem);

/// <summary> Smol record detailing an applied cursed item. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record AppliedItem(DateTimeOffset ReleaseTimeUTC, CursedLootType Type, Guid? RefId = null, GagType? Gag = null);
