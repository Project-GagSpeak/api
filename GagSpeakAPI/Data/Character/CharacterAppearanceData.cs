using MessagePack;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterAppearanceData
{
    // Properties specific to appearance data
    public string SlotOneGagType { get; set; } = "None";
    public string SlotOneGagPadlock { get; set; } = "None";
    public string SlotOneGagPassword { get; set; } = "";
    public DateTimeOffset SlotOneGagTimer { get; set; } = DateTimeOffset.Now;
    public string SlotOneGagAssigner { get; set; } = "";

    public string SlotTwoGagType { get; set; } = "None";
    public string SlotTwoGagPadlock { get; set; } = "None";
    public string SlotTwoGagPassword { get; set; } = "";
    public DateTimeOffset SlotTwoGagTimer { get; set; } = DateTimeOffset.Now;
    public string SlotTwoGagAssigner { get; set; } = "";

    public string SlotThreeGagType { get; set; } = "None";
    public string SlotThreeGagPadlock { get; set; } = "None";
    public string SlotThreeGagPassword { get; set; } = "";
    public DateTimeOffset SlotThreeGagTimer { get; set; } = DateTimeOffset.Now;
    public string SlotThreeGagAssigner { get; set; } = "";
}