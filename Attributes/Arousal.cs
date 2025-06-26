namespace GagspeakAPI.Attributes;

/// <summary> 
///     Determines the level of arousal given while restricted with an item.
///     Higher Arousal ratings generate higher total Arousal, or faster 
///     arousal Generation.
/// </summary>
public enum Arousal : byte
{
    None     = 0,
    Weak     = 1,
    Light    = 2,
    Mild     = 3,
    Strong   = 4,
}

