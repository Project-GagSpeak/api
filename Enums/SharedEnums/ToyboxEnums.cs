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
    TextDisplayOrdered = 0x00, // Phases display in the order they exist within the wordbank.
    TextDisplayRandom  = 0x01, // Phases display in a random order.

    // Bitmasks for Text Display
    TextDisplayMask = TextDisplayOrdered | TextDisplayRandom,

    LinearTextScale    = 0x02, // Display Phrases Gradually grow during their display time.
    RandomTextScale    = 0x04, // Display Phrases appear at randomized Scales.

    // Bitmasks for Text Scaling
    ScaleMask = LinearTextScale | RandomTextScale,

    TextFade           = 0x08, // Text will fade in & out between displays.
    InvertDirection    = 0x10, // Spins Counter Clockwise over Clockwise.

    SpeedUpOnCycle     = 0x20, // Text will speed up on each cycle.
    TransposeColors    = 0x40, // Goes between normal colors and inverted RGB every cycle.

    ArousalScalesSpeed = 0x80, // Display Cycle Speed impacted by by arousal. (WIP)
    ArousalPulsesText  = 0x100,// Display Cycle Pulse Speed impacted by arousal. (WIP)
}
