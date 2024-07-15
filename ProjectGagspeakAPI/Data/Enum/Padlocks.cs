namespace GagspeakAPI.Data.Enum;

/// <summary>
/// Various Padlock Types.
/// </summary
/// <summary> Padlock enum listing </summary>
public enum Padlocks
{
    None,                   // No gag
    MetalPadlock,           // Metal Padlock, can be picked
    CombinationPadlock,     // Combination Padlock, must enter 4 digit combo to unlock
    PasswordPadlock,        // Password Padlock, must enter password to unlock
    FiveMinutesPadlock,     // 5 minute padlock, must wait 5 minutes to unlock
    TimerPasswordPadlock,   // Timer Password Padlock, must enter password to unlock, but only after a certain amount of time
    MistressPadlock,        // Mistress Padlock, must ask mistress to unlock
    MistressTimerPadlock,   // Mistress Timer Padlock, must ask mistress to unlock, but only after a certain amount of time
};
