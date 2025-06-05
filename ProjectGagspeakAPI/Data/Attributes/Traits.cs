namespace GagspeakAPI.Data;

// Find some way to maybe make a better structure for this
// such that there wont be conflict between blindfold & hypnosis.
[Flags]
public enum Traits : short
{
    None             = 0x00, // 0000 0000
    LegsRestrained   = 0x01, // 0000 0001 (1 << 0)
    ArmsRestrained   = 0x02, // 0000 0010 (1 << 1)
    Gagged           = 0x04, // 0000 0100 (1 << 2)
    Blindfolded      = 0x08, // 0000 1000 (1 << 3)
    Hypnotized       = 0x10, // 0001 0000 (1 << 4)
    Immobile         = 0x20, // 0010 0000 (1 << 5)
    Weighty          = 0x40, // 0100 0000 (1 << 6)

    All = LegsRestrained | ArmsRestrained | Gagged | Blindfolded | Hypnotized | Immobile | Weighty,
}
