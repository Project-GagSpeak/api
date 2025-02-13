using GagspeakAPI.Enums;

namespace GagspeakAPI.Data.Interfaces;
public interface IPadlockableRestriction
{
    string Enabler { get; set; }
    Padlocks Padlock { get; set; }
    string Password { get; set; }
    DateTimeOffset Timer { get; set; }
    string PadlockAssigner { get; set; }
}

public interface IRestrictionValidator
{
    /// <summary> Retrieves if the padlock is locked. </summary>
    /// <returns> True if Padlock is not Padlock.ToPadlock().None. </returns>
    bool IsLocked();

    /// <summary> Retrieves if the timer has expired. </summary>
    /// <returns> True if DateTimeOffset.UtcNow is >= Timer </returns>
    bool HasTimerExpired();

    /// <summary> Validates if the padlock can be applied. </summary>
    bool CanApply();

    /// <summary> Validates if the padlock can be locked. </summary>
    bool CanLock();

    /// <summary> Validates if the padlock can be unlocked. </summary>
    bool CanUnlock();

    /// <summary> Validates if the padlock can be removed. </summary>
    bool CanRemove();
}
