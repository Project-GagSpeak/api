using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
///     Holds a lightweight version of the Client's storage to pass off to their Kinksters on connection. <para />
///     <b>Should only ever be sent on connection.</b> <para />
///     Folder structure mapping should be sent seperately as a base64 string.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaLightStorageData
{
    /// <summary> The GagRestrictionItems that are set to Enabled. </summary>
    public LightGag[] GagItems { get; set; } = [];
    public LightRestriction[] Restrictions { get; set; } = [];
    public LightRestraint[] Restraints  { get; set; } = [];
    public LightCollar Collar { get; set; } = new(string.Empty, new LightSlot(), string.Empty);
    public LightCursedLoot[] CursedItems { get; set; } = [];
    public LightPattern[] Patterns { get; set; } = [];
    public LightAlarm[] Alarms { get; set; } = [];
    public LightTrigger[] Triggers { get; set; } = [];
}

[MessagePackObject(keyAsPropertyName: true)]
public record LightRestriction(Guid Id, bool Enabled, RestrictionType Type, string Label, LightItem Properties);

[MessagePackObject(keyAsPropertyName: true)]
public record LightGag(GagType Gag, bool Enabled, LightItem Properties, string CPlusName, bool Redraw);

// This one kind of breaks convention a bit.
// Most of it is determined by server-side, so only store what is necessary for KinkPlates
[MessagePackObject(keyAsPropertyName: true)]
public record LightCollar(string Label, LightSlot Glamour, string ModName);

[MessagePackObject(keyAsPropertyName: true)]
public record LightCursedLoot(Guid Id, string Label, Precedence Precedence, CursedLootType Type, Guid? RefId = null, GagType? Gag = null);

[MessagePackObject(keyAsPropertyName: true)]
public record LightRestraint(Guid Id, bool Enabled, string Label, string Desc)
{
    public Dictionary<byte, LightSlotBasic> BasicSlots { get; init; } = [];
    public Dictionary<byte, LightSlotAdvanced> AdvancedSlots { get; init; } = [];
    public List<LightRestrictionLayer> RestrictionLayers { get; init; } = [];
    public List<LightModLayer> ModLayers { get; init; } = [];
    public List<string> Mods { get; init; } = [];
    public List<LightLoci> LociItems { get; init; } = [];
    public Traits BaseTraits { get; init; } = new();
    public Arousal Arousal { get; init; } = new();
    public bool Redraws { get; init; } = false;
};

[MessagePackObject(keyAsPropertyName: true)]
public record LightPattern(Guid Id, string Label, string Desc, TimeSpan Duration, bool Loops, ToyBrandName Device1, ToyBrandName Device2, ToyMotor Motors);


[MessagePackObject(keyAsPropertyName: true)]
public record LightAlarm(Guid Id, string Label, DateTimeOffset SetTimeUTC, Guid PatternId, DaysOfWeek SetDays);


[MessagePackObject(keyAsPropertyName: true)]
public record LightTrigger(Guid Id, int Priority, string Label, string Desc, TriggerKind Kind, InvokableActionType ActionType);


[MessagePackObject(keyAsPropertyName: true)]
public record LightSlotBasic(byte Slot, LightSlot Item, RestraintFlags Flags);


[MessagePackObject(keyAsPropertyName: true)]
public record LightSlotAdvanced(byte Slot, Guid RestrictionId, RestraintFlags Flags, byte Dye1, byte Dye2);


[MessagePackObject(keyAsPropertyName: true)]
public record LightRestrictionLayer(int LayerIdx, Guid Id, string Label, Arousal Arousal, Guid ItemRef, RestraintFlags Flags, byte Dye1, byte Dye2);


[MessagePackObject(keyAsPropertyName: true)]
public record LightModLayer(int LayerIdx, Guid Id, string Label, Arousal Arousal, string ModName);


[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LightSlot(byte Slot, ulong CItemId = uint.MaxValue, byte Dye1 = 0, byte Dye2 = 0);


[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LightItem(LightSlot Slot, string ModName, LightLoci LociData, Traits Traits, Arousal Arousal);


[MessagePackObject(keyAsPropertyName: true)]
public readonly record struct LightLoci(LociType Type, Guid Id);


