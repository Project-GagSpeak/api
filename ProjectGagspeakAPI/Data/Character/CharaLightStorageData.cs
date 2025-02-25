using GagspeakAPI.Data.Struct;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary> This contains a lightweight data packet of what we want to send over to other users for our contained data. </summary>
/// <remarks> This should only ever be sent after we finish editing any item. Not on every individual edit. Rearrangements Count. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaLightStorageData
{
    /// <summary> The GagRestrictionItems that are set to Enabled. </summary>
    public Dictionary<GagType, AppliedSlot> GagItems { get; internal init; } = [];
    public LightRestriction[] Restrictions { get; internal init; } = [];
    public LightRestraintSet[] Restraints  { get; internal init; } = [];
    public LightCursedItem[]  CursedItems { get; internal init; } = [];
    public LightPattern[]     Patterns    { get; internal init; } = [];
    public LightAlarm[]       Alarms      { get; internal init; } = [];
    public LightTrigger[]     Triggers    { get; internal init; } = [];
}


[MessagePackObject(keyAsPropertyName: true)]
public record LightGag(AppliedSlot SlotData, RestraintFlags Flags, Traits Traits)
{
    public string[] TraitAllowances { get; init; } = [];
}

[MessagePackObject(keyAsPropertyName: true)]
public record LightRestriction(Guid Id, string Label, string Desc, RestraintFlags Flags, Traits Traits)
{
    public AppliedSlot AffectedSlot { get; init; } = new();
    public string[] TraitAllowances { get; init; } = [];
}


[MessagePackObject(keyAsPropertyName: true)]
public record LightRestraintSet(Guid Id, string Label, string Desc, RestraintFlags Flags, Traits Traits)
{
    public List<AppliedSlot> AffectedSlots { get; init; } = [];
    public string[] TraitAllowances { get; init; } = [];
}

[MessagePackObject(keyAsPropertyName: true)]
public record LightCursedItem(Guid Id, string Label, RestrictionType Type)
{
    public GagType GagType { get; init; } = GagType.None;
    public Guid RestrictionId { get; init; } = Guid.Empty;
}

[MessagePackObject(keyAsPropertyName: true)]
public record LightPattern(Guid Id, string Label, string Desc, TimeSpan Duration, bool Loops);


[MessagePackObject(keyAsPropertyName: true)]
public record LightAlarm(Guid Id, string Label, DateTimeOffset SetTimeUTC, Guid PatternThatPlays);


[MessagePackObject(keyAsPropertyName: true)]
public record LightTrigger(Guid Id, int Priority, string Label, string Desc, TriggerKind Type, InvokableActionType ActionOnTrigger);


[MessagePackObject]
public record struct AppliedSlot(byte Slot = 3, ulong CustomItemId = ulong.MaxValue, string Tooltip = "");


