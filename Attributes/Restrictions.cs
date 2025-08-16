namespace GagspeakAPI.Attributes;

/// <summary>
///     Represents the type of restriction that is being applied.
/// </summary>
public enum RestrictionType
{
    Normal = 0,
    Blindfold = 1,
    Hypnotic = 2,
}

/// <summary>
///     The type of slot that is being applied.
/// </summary>
public enum RestraintSlotType
{
    Basic,
    Advanced,
}

/// <summary>
///     Represents the type of layer for restraint sets.
/// </summary>
public enum RestraintLayerType
{
    Restriction,
    ModPreset,
}

/// <summary>
///     Access areas for a collar restriction that can be modified.
/// </summary>
[Flags]
public enum CollarAccess : byte
{
    None = 0 << 0,
    Visuals = 1 << 0, // visuals are applied.
    Dyes = 1 << 1, // dyes are applied.
    // do not allow changing mods, this is too complicated.
    Moodle = 1 << 2, // moodle is applied.
    Writing = 1 << 3, // what is inscribe on the collar, (shown in kinkplates)

    AllButWriting = Visuals | Dyes | Moodle, // all access areas except writing.
    All = Visuals | Dyes | Moodle | Writing, // all access areas.
}
