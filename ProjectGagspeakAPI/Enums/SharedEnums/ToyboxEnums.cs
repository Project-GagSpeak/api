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
    TextIsSequential    = 0x00, // Displayed text cycles through the display words in order.
    TextIsRandom        = 0x01, // Displayed text pulls from the display words at random.

    ModeMask = TextIsSequential | TextIsRandom, // For easy masking

    RainbowGradient = 0x02, // The displayed hypnotic effect will cycle through a rainbow gradient.

    LinearTextScale     = 0x04, // The displayed will grow in time as the total duration gets closer to the end.
    RandomTextScale     = 0x08, // The displayed text appears in randomized scales each time the text cycles.
}
