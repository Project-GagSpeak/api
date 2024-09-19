namespace GagspeakAPI.Enums;


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
    OwnerPadlock,           // Can only be locked/unlocked by people with Owner Padlock perm Access
    OwnerTimerPadlock,      // Can only be locked/unlocked by people with Owner Padlock perm Access (Timed)
};
