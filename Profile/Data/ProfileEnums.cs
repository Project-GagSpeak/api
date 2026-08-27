namespace GagspeakAPI.Profiles;

public enum Alignment
{
    Left,
    Center,
    Right
}

// Can expand this to include the gagspeak font as well.
public enum TextFont
{
    Default,
    Scaled,
    Game,   
    Header,
    Subtitle,
    Title,
}

public enum RoleLean
{
    None,
    Unsure,
    Depends,
    MostlySubmissive,
    Submissive,
    Switch,
    MostlyDominant,
    Dominant,
    MoodBased,
    Wildcard,
}

// Should probably be replaced with kinks.
// Would be wise to make this strictly a database approved list of kinks.
public enum CharaInterest
{
    Achievements,
    AllianceRaids,
    Art,
    BlueMage,
    CasualRaids,
    Crafting,
    CriterionDungeons,
    DeepDungeons,
    Eeping,
    Events,
    ExtremeTrials,
    Fishing,
    Gathering,
    Glamour,
    Gposing,
    Housing,
    Hunts,
    Immersion,
    IslandSanctuary,
    Lore,
    Maps,
    Modding,
    Music,
    Performance,
    PvP,
    Questing,
    Raiding,
    Roleplay,
    SavageRaids,
    Sightseeing,
    Socializing,
    Story,
    Streaming,
    Venues,
    UltimateRaids,
}

/// <summary>
///   Defines which directions something should be applied to. <br/>
///   Designed for general use, but intended for top-left-down-right application.
/// </summary>
[Flags]
public enum DirectionFlags : int
{
    /// <summary> Does not apply to any direction. </summary>
    None = 0 << 0,

    /// <summary> applies to the top direction. </summary>
    Top = 1 << 1,

    /// <summary> applies to the left direction. </summary>
    Left = 1 << 2,

    /// <summary> applies to the right direction. </summary>
    Right = 1 << 3,

    /// <summary> applies to the bottom direction. </summary>
    Bottom = 1 << 4,

    /// <summary> applies to the top and bottom directions. </summary>
    Vertically = Top | Bottom,

    /// <summary> applies to the left and right directions. </summary>
    Horizontally = Left | Right,

    /// <summary> applies to all directions. </summary>
    All = Top | Left | Right | Bottom,
}

/// <summary>
///   Only the Corners properties of ImDrawFlags for API Use. <br/>
/// </summary>
[Flags]
public enum CornerDrawFlags : int
{
    /// <summary> Doesn't round anything. </summary>
    None = unchecked(0),

    /// <summary> Applies rounding to the TopLeft. </summary>
    TopLeft = unchecked(16),

    /// <summary> Applies rounding to the TopRight. </summary>
    TopRight = unchecked(32),

    /// <summary> Applies rounding to the BottomLeft. </summary>
    BottomLeft = unchecked(64),

    /// <summary> Applies rounding to the BottomRight. </summary>
    BottomRight = unchecked(128),

    /// <summary> Behaves the same as None. </summary>
    RoundingNone = unchecked(256),

    /// <summary> Applies rounding to the Top corners. </summary>
    Top = unchecked(48),

    /// <summary> Applies rounding to the Bottom corners. </summary>
    Bottom = unchecked(192),

    /// <summary> Applies rounding to the Left corners. </summary>
    Left = unchecked(80),

    /// <summary> Applies rounding to the Right corners. </summary>
    Right = unchecked(160),

    /// <summary> Applies rounding to all 4 corners. </summary>
    RoundAll = unchecked(240),
}