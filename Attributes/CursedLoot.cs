namespace GagspeakAPI.Attributes;


/// <summary> Determines the precedence level of a cursed item. </summary>
public enum Precedence
{
    VeryLow,
    Low,
    Default,
    High,
    VeryHigh,
    Highest
}

// redundant?
public enum CursedLootType
{
    None = 0,
    Restriction = 1,
    Gag = 2,
}

public enum LayerType
{
    Restriction,
    Mod,
}

