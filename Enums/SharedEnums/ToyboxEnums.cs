namespace GagspeakAPI.Enums;

public enum TriggerKind
{
    SpellAction = 0,
    HealthPercent = 1,
    RestraintSet = 2,
    Restriction = 3, 
    GagState = 4, // OLD = 3
    SocialAction = 5, // OLD = 4
    EmoteAction = 6, // OLD = 5
}

public enum ShockMode : sbyte // the OPCode
{
    Shock = 0,
    Vibrate = 1,
    Beep = 2,
}

[Flags]
public enum HypnoAttributes
{
    None               = 0x00, // No attributes are set.
    TextDisplayOrdered = 0x01, // Phases display in the order they exist within the wordbank.
    TextDisplayRandom  = 0x02, // Phases display in a random order.

    LinearTextScale    = 0x04, // Display Phrases Gradually grow during their display time.
    RandomTextScale    = 0x08, // Display Phrases appear at randomized Scales.

    TextFade           = 0x10, // Text will fade in & out between displays.
    InvertDirection    = 0x20, // Spins Counter Clockwise over Clockwise.

    SpeedUpOnCycle     = 0x40, // Text will speed up on each cycle.
    TransposeColors    = 0x80, // Goes between normal colors and inverted RGB every cycle.

    ArousalScalesSpeed = 0x100,// Display Cycle Speed impacted by by arousal. (WIP)
    ArousalPulsesText  = 0x200,// Display Cycle Pulse Speed impacted by arousal. (WIP)

    Default = TextDisplayOrdered | LinearTextScale,
    // Bitmasks for Text Display
    TextDisplayMask = TextDisplayOrdered | TextDisplayRandom,
    // Bitmasks for Text Scaling
    ScaleMask = LinearTextScale | RandomTextScale,
}

public static class HypnoAttrExtensions
{
    public static readonly HypnoAttributes[] RawFlags = Enum.GetValues<HypnoAttributes>()
        .Where(f => ((int)f & ((int)f - 1)) == 0)
        .OrderBy(f => (int)f)
        .ToArray();

    public static readonly HypnoAttributes[] ToggleFlags = RawFlags.Skip(5).ToArray();

}
