namespace GagspeakAPI.Attributes;

public enum RemoteType
{
    None,
    Personal,
    Recording,
    Playback,
    VibeRoom,
}

/// <summary>
///     Type of Motor for a Buzztoy.
///     Keep index's static.
/// </summary>
[Flags]
public enum ToyMotor
{
    Unknown       = 0,
    Vibration     = 1 << 0,
    Oscillation   = 1 << 1,
    Rotation      = 1 << 2,
    Constriction  = 1 << 3,
    Inflation     = 1 << 4,
    Position      = 1 << 5,
}

/// <summary>
///     The Brand Name associated with a Toy. <para/>
///     Lovense will release new toys, and other devies may be added, so keep index's static to not disrupt Database.
/// </summary>
public enum ToyBrandName
{
    Unknown = 0,
    Ambi = 1,
    Calor = 2,
    Diamo = 3,
    Dolce = 4,
    Domi = 5,
    Domi2 = 6,
    Edge = 7,
    Edge2 = 8,
    Exomoon = 9,
    Ferri = 10,
    Flexer = 11,
    Gemini = 12,
    Gravity = 13,
    Gush = 14,
    Gush2 = 15,
    Hush = 16,
    Hush2 = 17,
    Hyphy = 18,
    Lapis = 19,
    MiniSexMachine = 20,
    SexMachine = 21,
    Lush = 22,
    Lush2 = 23,
    Lush3 = 24,
    Lush4 = 25,
    Max = 26,
    Max2 = 27,
    Mission = 28,
    Mission2 = 29,
    Nora = 30,
    Osci = 31,
    Osci2 = 32,
    Osci3 = 33,
    Ridge = 34,
    Solace = 35,
    SolacePro = 36,
    Tenera2 = 37,
    Vulse = 38,
    HismithSexMachine = 39,
}
