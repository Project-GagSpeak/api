using GagspeakAPI.Enums;
using GagspeakAPI.Data.Interfaces;
using MessagePack;
using GagspeakAPI.Extensions;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// Represents character appearance data including multiple gag slots.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CharaAppearanceData
{
    // Fixed size array of GagSlots
    public GagSlot[] GagSlots { get; init; } = new GagSlot[3]
    {
        new GagSlot(), // Slot 1
        new GagSlot(), // Slot 2
        new GagSlot()  // Slot 3
    };

    public string ToGagString()
        => $"{string.Join("\n", GagSlots.Select(g => g.ToString()))}";

    public CharaAppearanceData DeepCloneData()
    {
        var clone = new CharaAppearanceData();
        for (var i = 0; i < GagSlots.Length; i++)
        {
            clone.GagSlots[i] = GagSlots[i].DeepCloneData();
        }
        return clone;
    }
}

/// <summary>
/// Represents a gag slot with various attributes.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record GagSlot : IPadlockable
{
    public string GagType { get; set; } = "None";
    public string Padlock { get; set; } = Padlocks.None.ToName();
    public string Password { get; set; } = "";
    public DateTimeOffset Timer { get; set; } = DateTimeOffset.Now;
    public string Assigner { get; set; } = "";

    public override string ToString()
        => $"GagSlot {{ GagType = {GagType}, Padlock = {Padlock}, Password = {Password}, Timer = {Timer}, Assigner = {Assigner} }}";

    public GagSlot() { }
    public GagSlot DeepCloneData()
        => new GagSlot
        {
            GagType = GagType,
            Padlock = Padlock,
            Password = Password,
            Timer = Timer,
            Assigner = Assigner
        };

    public bool IsLocked() => Padlock != Padlocks.None.ToName();
    public bool HasTimerExpired() => Timer < DateTimeOffset.UtcNow;
}
