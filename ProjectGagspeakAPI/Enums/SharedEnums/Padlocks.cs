namespace GagspeakAPI.Enums;

/// <summary> Padlock enum listing </summary>
public enum Padlocks
{
    None,                   // No gag
    MetalPadlock,           // Metal Padlock, can be picked
    FiveMinutesPadlock,     // 5 minute padlock, must wait 5 minutes to unlock
    CombinationPadlock,     // Combination Padlock, must enter 4 digit combo to unlock
    PasswordPadlock,        // Password Padlock, must enter password to unlock
    TimerPadlock,           // Timer Padlock, must wait a certain amount of time to unlock
    TimerPasswordPadlock,   // Timer Password Padlock, must enter password to unlock, but only after a certain amount of time
    OwnerPadlock,           // Can only be locked/unlocked by people with Owner Padlock perm Access
    OwnerTimerPadlock,      // Can only be locked/unlocked by people with Owner Padlock perm Access (Timed)
    DevotionalPadlock,      // Can only be unlocked by the same person who locked it. (or safeword)
    DevotionalTimerPadlock, // Can only be unlocked by the same person who locked it. (or safeword) (Timed)
    MimicPadlock,           // Mimic Padlock, a Timed Padlock that Cannot be unlocked. (Only Applied by Mimics)
};

/// <summary> Flag-Based enumerable to identify what errors occur in padlock validation. </summary>
[Flags]
public enum PadlockReturnCode
{
    Success = 0,
    NoPadlockSelected = 1 << 0,
    InvalidCombination = 1 << 1,
    InvalidPassword = 1 << 2,
    InvalidTime = 1 << 3,
    PermanentRestricted = 1 << 4,
    OwnerRestricted = 1 << 5,
    DevotionalRestricted = 1 << 6,
    LockingRestricted = 1 << 7,
    UnlockingRestricted = 1 << 8,
    NotLockAssigner = 1 << 9,
}

