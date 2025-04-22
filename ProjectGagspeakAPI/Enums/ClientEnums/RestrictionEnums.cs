using System.ComponentModel.DataAnnotations;

namespace GagspeakAPI.Enums;

// We handle this through individual cases because its more efficient 
public static class FlagEx
{
    // we avoid doing generic types here because it actually increases the processing time in the compiler if we convert to ambiguous types.
    public static bool HasAny(this HardcoreTraits flags, HardcoreTraits check) => (flags & check) != 0;
    public static bool HasAny(this Traits flags, Traits check) => (flags & check) != 0;
    public static bool HasAny(this Stimulation flags, Stimulation check) => (flags & check) != 0;
    public static bool HasAny(this RestraintFlags flags, RestraintFlags check) => (flags & check) != 0;
    public static bool HasAny(this VisualUpdateFlags flags, VisualUpdateFlags check) => (flags & check) != 0;
    public static bool HasAny(this PuppetPerms flags, PuppetPerms check) => (flags & check) != 0;
    public static bool HasAny(this MoodlePerms flags, MoodlePerms check) => (flags & check) != 0;

    /// <summary> Strictly to be used for debugging purposes. </summary>
    /// <param name="flags"> The flags to check. </param>
    /// <returns> A string representation of the individual flags that are set. </returns>
    /// <remarks> Throws exception if enum type is not a [Flags] enum. </remarks>
    /// <exception cref="ArgumentException"></exception>
    public static string ToSplitFlagString<TEnum>(this TEnum value) where TEnum : struct, Enum
    {
        var type = typeof(TEnum);
        if (!type.IsEnum || !Attribute.IsDefined(type, typeof(FlagsAttribute)))
            throw new ArgumentException("ToIndividualFlagsString can only be used with [Flags] enums.");

        var inputValue = Convert.ToUInt64(value); // Handles all enum base types
        if (inputValue == 0)
            return value.ToString(); // Typically "None"

        var individualFlags = Enum.GetValues(type)
            .Cast<Enum>()
            .Where(flag =>
            {
                var flagValue = Convert.ToUInt64(flag);
                return flagValue != 0 && IsPowerOfTwo(flagValue) && (inputValue & flagValue) == flagValue;
            });

        return string.Join(", ", individualFlags.Select(f => f.ToString()));

        static bool IsPowerOfTwo(ulong x) => (x & (x - 1)) == 0;
    }
}

public enum ModuleSection
{
    None,
    Restraint,
    Restriction,
    Gag,
    CursedLoot,
    Puppeteer,
    Pattern,
    Alarm,
    Trigger,
}

[Flags]
public enum Traits : short
{
    None = 0x00,
    LegsRestrained = 0x01,
    ArmsRestrained = 0x02,
    Gagged = 0x04,
    Blindfolded = 0x08,
    Immobile = 0x10,
    Weighty = 0x20,
}

public enum Stimulation : byte
{
    None    = 0x00,
    Light   = 0x01,
    Mild    = 0x02,
    Heavy   = 0x04,

    Any = Light | Mild | Heavy,
}

[Flags]
public enum HardcoreTraits : byte
{
    None             = 0x00,
    ForceFollow      = 0x01,
    ForceEmote       = 0x02,
    ForceStay        = 0x04,
    ChatBoxHidden    = 0x08,
    ChatInputHidden  = 0x10,
    ChatInputBlocked = 0x20,
}

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

/// <summary> Helps track what changes were made during application or removal of a restriction. </summary>
[Flags]
public enum VisualUpdateFlags : byte
{
    None =             0x0,  // (0)  (( 1 << 0 ))
    Glamour =          0x1,  // (1)  (( 1 << 0 ))
    Mod =              0x2,  // (2)  (( 1 << 1 ))
    Moodle =           0x4,  // (4)  (( 1 << 2 ))
    Helmet =           0x8,  // (8)  (( 1 << 3 ))
    Visor =            0x10, // (16) (( 1 << 4 ))
    Weapon =           0x20, // (32) (( 1 << 5 ))
    CustomizeProfile = 0x40, // (64) (( 1 << 6 ))

    AllGag = Glamour | Mod | Moodle | Helmet | Visor | Weapon | CustomizeProfile,
    AllRestriction = Glamour | Mod | Moodle,
    AllRestraint = Glamour | Mod | Moodle | Helmet | Visor | Weapon | CustomizeProfile,
}

/// <summary> The type of Moodle that is being applied. </summary>
public enum MoodleType 
{
    Status = 0,
    Preset = 1
}

/// <summary> The kind of change being made to the current restriction (Will be removed later) </summary>
public enum StorageItemChangeType
{
    Created,
    Deleted,
    Renamed,
    Modified,
}

public enum RestrictionType
{
    Normal = 0,
    Blindfold = 1,
    Hypnotic = 2,
    Collar = 3,
    Gag = 4,
}

/// <summary> The type of slot that is being applied. </summary>
public enum RestraintSlotType 
{
    Basic,
    Advanced,
}

public enum RestraintLayerType
{
    Restriction,
    ModPreset,
}

/// <summary> The Priority order of all Managers for the visual state. </summary>
public enum ManagerPriority : byte
{
    Restraints = 0,
    Restrictions = 1,
    Gags = 2,
    CursedLoot = 3
}
