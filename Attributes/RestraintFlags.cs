using GagspeakAPI.Extensions;

namespace GagspeakAPI.Attributes;

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
    Arousal =   0x10, // Apply Arousal While Active
    IsOverlay = 0x20, // Apply as an Overlay

    // Basic Application Type for advanced Restrictions.
    Restriction = Glamour | Mod | Moodle | Trait | Arousal,
    Advanced = Glamour | Mod | Moodle | Trait | Arousal | IsOverlay,
}

/// <summary>
///    Flag-Based Enum detailing the various layers of Restraint Items.
/// </summary>
[Flags]
public enum RestraintLayer : byte
{
    None   = 0,
    Layer1 = 1 << 0,
    Layer2 = 1 << 1,
    Layer3 = 1 << 2,
    Layer4 = 1 << 3,
    Layer5 = 1 << 4,

    All = Layer1 | Layer2 | Layer3 | Layer4 | Layer5,
}


// Maybe expand upon here but not really sure.
public static class RSLayerExtensions
{
    /// <summary>
    ///     Yields each set bit as its layer idx (0-4), will need to +1 for keys.
    /// </summary>
    public static IEnumerable<int> GetLayerIndices(this RestraintLayer layers)
    {
        for (int i = 0; i < 5; i++)
            if (layers.HasAny((RestraintLayer)(1 << i)))
                yield return i;
    }
}
