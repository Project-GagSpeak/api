namespace GagspeakAPI.Data;

/// <summary>
///     Flag-Based Enum detailing the various attributes of a Restraint Item.
/// </summary>
/// <remarks> May be removed later after a rework to cache management. </remarks>
[Flags]
public enum RestraintFlags : sbyte
{
    Glamour =   0x01, // Apply Glamour Item
    Mod =       0x02, // Apply Mod while active.
    Moodle =    0x04, // Apply Moodle While Active
    Trait =     0x08, // Apply Traits While Active
    IsOverlay = 0x10, // Apply as an Overlay

    // Basic Application Type for advanced Restrictions.
    Restriction = Glamour | Mod | Moodle | Trait,
    Advanced = Glamour | Mod | Moodle | Trait | IsOverlay,
}
