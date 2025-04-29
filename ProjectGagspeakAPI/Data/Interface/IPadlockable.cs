using GagspeakAPI.Enums;

namespace GagspeakAPI.Data;

public interface IPadlockable
{
    string Enabler { get; }
    Padlocks Padlock { get; }
    string Password { get; }
    DateTimeOffset Timer { get; }
    string PadlockAssigner { get; }
}
public interface IPadlockableRestriction : IPadlockable
{
    /// <summary> Retrieves if the padlock is locked. </summary>
    /// <returns> True if Padlock is not Padlock.None </returns>
    bool IsLocked();

    /// <summary> Retrieves if the timer has expired. </summary>
    /// <returns> True if DateTimeOffset.UtcNow is >= Timer </returns>
    bool HasTimerExpired();
}

public interface IRestrictionValidator
{

    /// <summary> Validates if the padlock can be applied. </summary>
    bool CanApply();

    /// <summary> Validates if the padlock can be locked. </summary>
    bool CanLock();

    /// <summary> Validates if the padlock can be unlocked. </summary>
    bool CanUnlock();

    /// <summary> Validates if the padlock can be removed. </summary>
    bool CanRemove();
}
