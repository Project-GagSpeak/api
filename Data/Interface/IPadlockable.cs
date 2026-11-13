using GagspeakAPI.Enums;

namespace GagspeakAPI.Data;

public interface IPadlockable
{
    string Enabler { get; }
    Padlocks Padlock { get; }
    string Password { get; }
    DateTimeOffset Timer { get; }
    string PadlockAssigner { get; }

    /// <summary> Retrieves if the padlock is locked. </summary>
    /// <returns> True if Padlock is not Padlock.None </returns>
    bool IsLocked();

    /// <summary> Retrieves if the timer has expired. </summary>
    /// <returns> True if DateTimeOffset.UtcNow is >= Timer </returns>
    bool TimerExpired();
}