using GagspeakAPI.Enums;
using GagspeakAPI.Data.Interfaces;
using MessagePack;
using GagspeakAPI.Extensions;

namespace GagspeakAPI.Data.Character;

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveGags
{
    public ActiveGagSlot[] GagSlots { get; init; } = new ActiveGagSlot[3];
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

    public ActiveGagSlot() { }

    public override string ToString()
        => $"GagSlot {{ GagItem = {GagItem.GagName()}, Padlock = {Padlock.ToName()}, " +
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
    public ActiveRestriction[] Restrictions { get; init; } = new ActiveRestriction[5];
    public string ToGagString() => string.Join("\n", Restrictions.Select(g => g.ToString()));
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

    public ActiveRestriction() { }

    public override string ToString()
        => $"Item: {{ ID = {Identifier}, Lock = {Padlock.ToName()}, " +
           $"Pass = {Password}, Timer = {Timer}, Assigner = {PadlockAssigner} }}";
    public bool IsLocked() => Padlock != Padlocks.None;
    public bool HasTimerExpired() => Timer < DateTimeOffset.UtcNow;
    public bool CanApply() => !IsLocked();
    public bool CanLock() => !Identifier.IsEmptyGuid() && !IsLocked();
    public bool CanUnlock() => IsLocked() && !Identifier.IsEmptyGuid();
    public bool CanRemove() => !Identifier.IsEmptyGuid() && !IsLocked();
}

[MessagePackObject(keyAsPropertyName: true)]
public record CharaActiveRestraint : ActiveRestriction
{
    /// <summary> Bitfield representing which layers are active, 5 bits : 0b00000 </summary>
    public byte LayersBitfield { get; set; } = 0b00000;

    public CharaActiveRestraint() { }

    public override string ToString()
        => $"Restraint: {{ ID = {Identifier}, Layers = {LayersBitfield}, " +
           $"Lock = {Padlock.ToName()}, Pass = {Password}, Timer = {Timer}, Assigner = {PadlockAssigner} }}";

    public bool IsLayerActive(int idx) => (LayersBitfield & (1 << idx)) != 0;
    public void SetLayerActive(int idx) => LayersBitfield |= (byte)(1 << idx);
    public void SetLayerInactive(int idx) => LayersBitfield &= (byte)~(1 << idx);
    public void ClearLayers() => LayersBitfield = 0b00000;
}
