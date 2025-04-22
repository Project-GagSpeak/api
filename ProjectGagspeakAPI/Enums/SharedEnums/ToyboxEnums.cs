namespace GagspeakAPI.Enums;

public enum TriggerKind
{
    SpellAction = 0,
    HealthPercent = 1,
    RestraintSet = 2,
    Restriction = 6,
    GagState = 3,
    SocialAction = 4,
    EmoteAction = 5,
}

public enum ShockMode : sbyte // the OPCode
{
    None = -1,
    Shock = 0,
    Vibrate = 1,
    Beep = 2,
}

[Flags]
public enum HypnoAttributes
{
    TextIsSequential    = 0x00, // Displayed text cycles through the display words in order.
    TextIsRandom        = 0x01, // Displayed text pulls from the display words at random.

    RainbowGradient     = 0x02, // The displayed hypnotic effect will cycle through a rainbow gradient.

    LinearTextScale     = 0x04, // The displayed will grow in time as the total duration gets closer to the end.
    RandomTextScale     = 0x08, // The displayed text appears in randomized scales each time the text cycles.
}
