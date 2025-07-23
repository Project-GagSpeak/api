namespace GagspeakAPI.Enums;

/// <summary> Padlock enum listing </summary>
public enum Padlocks
{
    None,            // No gag
    Metal,           // Metal Padlock, can be picked
    FiveMinutes,     // 5 minute padlock, must wait 5 minutes to unlock
    Combination,     // Combination Padlock, must enter 4 digit combo to unlock
    Password,        // Password Padlock, must enter password to unlock
    Timer,           // Timer Padlock, can wait for expiration or unlock whenever.
    PredicamentTimer,// Timer Padlock, must wait for expiration. Can be unlocked whenever by anyone but the Kinkster the lock is on.
    TimerPassword,   // Timer Password Padlock, must enter password to unlock, but only after a certain amount of time
    Owner,           // Can only be locked/unlocked by people with Owner Padlock perm Access
    OwnerTimer,      // Can only be locked/unlocked by people with Owner Padlock perm Access (Timed)
    Devotional,      // Can only be unlocked by the same person who locked it. (or safeword)
    DevotionalTimer, // Can only be unlocked by the same person who locked it. (or safeword) (Timed)
    Mimic,           // Mimic Padlock, a Timed Padlock that Cannot be unlocked. (Only Applied by Mimics)
};

