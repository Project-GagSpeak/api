using GagspeakAPI.Attributes;
using GagspeakAPI.Enums;
using GagspeakAPI.Util;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveGags
{
    public CharaActiveGags()
    {
        for (var i = 0; i < GagSlots.Length; i++)
            GagSlots[i] = new ActiveGagSlot();
    }

    // Constructor with predefined slots (for server)
    public CharaActiveGags(ActiveGagSlot[] slots)
    {
        for (var i = 0; i < GagSlots.Length; i++)
            GagSlots[i] = slots[i];
    }

    public ActiveGagSlot[] GagSlots { get; init; } = new ActiveGagSlot[Constants.MaxGagSlots]; // Fixed Length 3
    public string ToGagString() => string.Join("\n", GagSlots.Select(g => g.ToString()));
}

[MessagePackObject(keyAsPropertyName: true)]
public record ActiveGagSlot : IPadlockableRestriction, IRestrictionValidator
{
    public GagType GagItem { get; set; } = GagType.None;
    public string Enabler { get; set; } = string.Empty;
    public Padlocks Padlock { get; set; } = Padlocks.None;
    public string Password { get; set; } = string.Empty;
    public DateTimeOffset Timer { get; set; } = DateTimeOffset.Now;
    public string PadlockAssigner { get; set; } = string.Empty;
    public override string ToString()
        => $"GagSlot {{ GagItem = {GagItem.GagName()}, Enabler = {Enabler}, Padlock = {Padlock.ToName()}, " +
           $"Password = {Password}, Timer = {Timer}, Assigner = {PadlockAssigner} }}";

    public bool IsLocked() => Padlock != Padlocks.None;
    public bool HasTimerExpired() => Timer < DateTimeOffset.UtcNow;

    public bool CanApply() => !IsLocked();
    public bool CanLock() => GagItem != GagType.None && !IsLocked();
    public bool CanUnlock() => IsLocked() && GagItem != GagType.None;
    public bool CanRemove() => GagItem != GagType.None && !IsLocked();
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveRestrictions
{
    public CharaActiveRestrictions()
    {
        for (var i = 0; i < Restrictions.Length; i++)
            Restrictions[i] = new ActiveRestriction();
    }

    // Constructor with predefined restrictions (for server)
    public CharaActiveRestrictions(ActiveRestriction[] restrictions)
    {
        for (var i = 0; i < Restrictions.Length; i++)
            Restrictions[i] = restrictions[i];
    }

    public ActiveRestriction[] Restrictions { get; init; } = new ActiveRestriction[Constants.MaxRestrictionSlots];
    public string ToRestrictionString() => string.Join("\n", Restrictions.Select(g => g.ToString()));
}

[MessagePackObject(keyAsPropertyName: true)]
public record ActiveRestriction : IPadlockableRestriction, IRestrictionValidator
{
    public Guid Identifier { get; set; } = Guid.Empty;
    public string Enabler { get; set; } = string.Empty;
    public Padlocks Padlock { get; set; } = Padlocks.None;
    public string Password { get; set; } = string.Empty;
    public DateTimeOffset Timer { get; set; } = DateTimeOffset.Now;
    public string PadlockAssigner { get; set; } = string.Empty;

    public override string ToString()
        => $"Item: {{ ID = {Identifier}, Lock = {Padlock.ToName()}, " +
           $"Pass = {Password}, Timer = {Timer}, Assigner = {PadlockAssigner} }}";

    public bool IsLocked() => Padlock != Padlocks.None;
    public bool HasTimerExpired() => Timer < DateTimeOffset.UtcNow;

    public bool CanApply() => !IsLocked();
    public bool CanLock() => Identifier != Guid.Empty && !IsLocked();
    public bool CanUnlock() => IsLocked() && Identifier != Guid.Empty;
    public bool CanRemove() => Identifier != Guid.Empty && !IsLocked();
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveRestraint : ActiveRestriction
{
    /// <summary> Bitfield representing which layers are active, 5 bits : 0b00000 </summary>
    public RestraintLayer ActiveLayers { get; set; } = RestraintLayer.None;

    public CharaActiveRestraint() : base() { }

    public override string ToString()
        => $"Restraint: {{ ID = {Identifier}, ActiveLayers = {ActiveLayers}, " +
           $"Lock = {Padlock.ToName()}, Pass = {Password}, Timer = {Timer}, Assigner = {PadlockAssigner} }}";
}
