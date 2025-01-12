using GagspeakAPI.Enums;

namespace GagspeakAPI.Data.Interfaces;
public interface IPadlockable
{
    string Padlock { get; set; } // Stored Padlock.
    string Password { get; set; } // Stored Password
    DateTimeOffset Timer { get; set; } // Timer in UTC
    string Assigner { get; set; } // Assigner Name

    // helper func to check if the padlock is locked.
    bool IsLocked();
    bool HasTimerExpired();
}
