using GagspeakAPI.Enums;
using GagspeakAPI.Data.Interfaces;
using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// Represents character appearance data including multiple gag slots.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CharacterAppearanceData
{
    // Fixed size array of GagSlots
    public GagSlot[] GagSlots { get; init; } = new GagSlot[3]
    {
        new GagSlot(), // Slot 1
        new GagSlot(), // Slot 2
        new GagSlot()  // Slot 3
    };
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
}
