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
