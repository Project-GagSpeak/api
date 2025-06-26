namespace GagspeakAPI.Attributes;

[Flags]
public enum Traits : short
{
    None        = 0x00, // (0 << 0)
    BoundLegs   = 0x01, // (1 << 0) Cannot Use Legs
    BoundArms   = 0x02, // (1 << 1) Cannot Use Arms
    Gagged      = 0x04, // (1 << 2) Speech is Restricted
    Blindfolded = 0x08, // (1 << 3) Sight is Restricted
    Immobile    = 0x20, // (1 << 5) Body Cannot Move, only Hobble
    Weighty     = 0x40, // (1 << 6) Fatiqued / Slow Movement.

    All = BoundLegs | BoundArms | Gagged | Blindfolded | Immobile | Weighty,
}
