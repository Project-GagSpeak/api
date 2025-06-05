using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary> This contains a lightweight data packet of what we want to send over to other users for our contained data. </summary>
/// <remarks> This should only ever be sent after we finish editing any item. Not on every individual edit. Rearrangements Count. </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaLightStorageData
{
    /// <summary> The GagRestrictionItems that are set to Enabled. </summary>
    public Dictionary<GagType, AppliedSlot> GagItems { get; init; } = [];
    public LightRestriction[] Restrictions { get; init; } = [];
    public LightRestraintSet[] Restraints  { get; init; } = [];
    public LightCursedItem[] CursedItems { get; init; } = [];
    public LightPattern[] Patterns { get; init; } = [];
    public LightAlarm[] Alarms { get; init; } = [];
    public LightTrigger[] Triggers { get; init; } = [];
    public Dictionary<GagspeakModule, string[]> Allowances { get; init; } = [];
}


[MessagePackObject(keyAsPropertyName: true)]
public record LightGag(AppliedSlot SlotData, Attributes Attributes);


[MessagePackObject(keyAsPropertyName: true)]
public record LightRestriction(Guid Id, string Label, string Description, AppliedSlot Item, Attributes Attributes);


[MessagePackObject(keyAsPropertyName: true)]
public record LightRestraintSet(Guid Id, string Label, string Description, List<AppliedSlot> AffectedSlots, Attributes Attributes);


[MessagePackObject(keyAsPropertyName: true)]
public record LightCursedItem(Guid Id, string Label, GagType GagType, Guid RestrictionRef, DateTimeOffset ReleaseTimeUTC);


[MessagePackObject(keyAsPropertyName: true)]
public record LightPattern(Guid Id, string Label, string Description, TimeSpan Duration, bool Loops);


[MessagePackObject(keyAsPropertyName: true)]
public record LightAlarm(Guid Id, string Label, DateTimeOffset SetTimeUTC, Guid PatternThatPlays);


[MessagePackObject(keyAsPropertyName: true)]
public record LightTrigger(Guid Id, int Priority, string Label, string Description, TriggerKind Type, InvokableActionType ActionOnTrigger);


[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct AppliedSlot(byte Slot = 3, ulong CustomItemId = ulong.MaxValue, string Tooltip = "");


[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct Attributes(RestraintFlags Flags, Traits HcTraits, Stimulation Stimulation);


