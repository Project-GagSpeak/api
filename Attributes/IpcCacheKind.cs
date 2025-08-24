namespace GagspeakAPI.Attributes;

/// <summary>
///     What kinds of caches are in queue for processing.
/// </summary>
[Flags]
public enum DataSyncKind : byte
{
    None        = 0,      // byte (0)

    Glamourer   = 1 << 0, // byte (1)
    ModManips   = 1 << 1, // byte (2)
    Heels       = 1 << 2, // byte (4)
    CPlus       = 1 << 3, // byte (8)
    Honorific   = 1 << 4, // byte (16)
    PetNames    = 1 << 5, // byte (32)
}
