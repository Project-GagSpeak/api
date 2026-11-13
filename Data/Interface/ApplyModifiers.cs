namespace GagspeakAPI.Data;

// Used to determine which parts of an active item are to be used.
[Flags]
public enum ApplyModifiers : short
{
    None = 0 << 0,
    DoEmote = 1 << 0,
    FirstPerson = 1 << 1,
    ShowOverlay = 1 << 2,
    Arousal = 1 << 3,
    HCTraits = 1 << 4,
}