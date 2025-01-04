using GagspeakAPI.Data;
using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace GagspeakAPI.Extensions;

public static class LockHelperExtensions
{
    public static readonly HashSet<Padlocks> AllLocksWithMimic = Enum.GetValues<Padlocks>().ToHashSet();
    public static readonly HashSet<Padlocks> AllLocks = Enum.GetValues<Padlocks>().Where(p => p != Padlocks.MimicPadlock).ToHashSet();
    public static readonly HashSet<Padlocks> TwoRowLocks = new()
    {
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
        Padlocks.OwnerTimerPadlock,
        Padlocks.DevotionalTimerPadlock
    };

    public static readonly HashSet<Padlocks> PermanentLocks = new()
    {
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.OwnerPadlock,
        Padlocks.DevotionalPadlock
    };

    public static readonly HashSet<Padlocks> PasswordPadlocks = new()
    {
        Padlocks.PasswordPadlock,
        Padlocks.TimerPasswordPadlock
    };

    public static readonly HashSet<Padlocks> TimerLocks = new()
    {
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
        Padlocks.OwnerTimerPadlock,
        Padlocks.DevotionalTimerPadlock
    };

    public static readonly HashSet<Padlocks> OwnerLocks = new()
    {
        Padlocks.OwnerPadlock,
        Padlocks.OwnerTimerPadlock
    };

    public static readonly HashSet<Padlocks> DevotionalLocks = new()
    {
        Padlocks.DevotionalPadlock,
        Padlocks.DevotionalTimerPadlock
    };

    public static bool IsTwoRowLock(this Padlocks padlock) => TwoRowLocks.Contains(padlock);
    public static bool IsPermanentLock(this Padlocks padlock) => PermanentLocks.Contains(padlock);
    public static bool IsPasswordLock(this Padlocks padlock) => PasswordPadlocks.Contains(padlock);
    public static bool IsTimerLock(this Padlocks padlock) => TimerLocks.Contains(padlock) || padlock == Padlocks.MimicPadlock || padlock == Padlocks.FiveMinutesPadlock;
    public static bool IsOwnerLock(this Padlocks padlock) => OwnerLocks.Contains(padlock);
    public static bool IsDevotionalLock(this Padlocks padlock) => DevotionalLocks.Contains(padlock);

    // Need to make a function that makes use of this class to create a final return list of lock types based on permissions from a passed in permission object that can have a bool for AllowDevotional, AllowOwner, AllowPerminant, AllowLocks.
    // This function will be used to determine what locks can be applied to a user based on the permissions of the user.
    public static IEnumerable<Padlocks> GetLocksForPair(UserPairPermissions permissions)
    {
        // if we have no lock permissions return only Padlock.None.
        if (!permissions.LockGags) return new HashSet<Padlocks> { Padlocks.None };

        // Otherwise, calculate the locks.
        var allowedLocks = new HashSet<Padlocks>(AllLocks);

        // exclude if we are missing permissions.
        if (!permissions.PermanentLocks) allowedLocks.ExceptWith(PermanentLocks);
        if (!permissions.OwnerLocks) allowedLocks.ExceptWith(OwnerLocks);
        if (!permissions.DevotionalLocks) allowedLocks.ExceptWith(DevotionalLocks);

        return allowedLocks;
    }

    /// <summary>
    /// A static helper method to validate the desired application of a lock to an item, and if so, to apply updates to its data.
    /// <para>
    /// It is recommended whatever is passed in should be a deepClone and not the raw data, as this method will modify the data.
    /// </para>
    /// </summary>
    /// <typeparam name="T">An Active Restraint Data or GagPadlock.</typeparam>
    /// <param name="item">The Restraint/GagPadlock we are wanting to check against for data.</param>
    /// <param name="lockDesired">The new Padlock we wish to set it to.</param>
    /// <param name="pass">The new password we wish to set for the lock.</param>
    /// <param name="time">the time we want to lock it for.</param>
    /// <param name="assign">the UID that is attempting to make this change.</param>
    /// <param name="perms">the permissions that the pair has set for us.</param>
    /// <returns>
    /// If the verification was successful, and any error string if possible. 
    /// If Valid, item will be updated with its new information to send off.
    /// </returns>
    public static (bool isValid, string logMsg) VerifyLock<T>(ref T item, Padlocks lockDesired, string pass, string time, string assigner, UserPairPermissions perms) where T : IPadlockable
    {
        // return invalid failure if lock gags permission is false or if the lock type is none.
        if (!perms.LockGags) return (false, "You don't have permission to apply locks.");
        if (lockDesired is Padlocks.None) return (false, "No padlock selected.");
        
        // construct the operations performed to evaluate the lock.
        var lockValidations = new Dictionary<Padlocks, Func<bool>>
        {
            { Padlocks.MetalPadlock, () => true },
            { Padlocks.CombinationPadlock, () => IsValidCombo(pass) && perms.PermanentLocks },
            { Padlocks.PasswordPadlock, () => IsValidPass(pass) && perms.PermanentLocks },
            { Padlocks.TimerPadlock, () => IsValidTime(time, perms.MaxGagTime) },
            { Padlocks.TimerPasswordPadlock, () => IsValidPass(pass) && IsValidTime(time, perms.MaxGagTime) },
            { Padlocks.OwnerPadlock, () => perms.OwnerLocks && perms.PermanentLocks },
            { Padlocks.OwnerTimerPadlock, () => perms.OwnerLocks && IsValidTime(time, perms.MaxGagTime) },
            { Padlocks.DevotionalPadlock, () => perms.DevotionalLocks && perms.PermanentLocks },
            { Padlocks.DevotionalTimerPadlock, () => perms.DevotionalLocks && IsValidTime(time, perms.MaxGagTime) }
        };

        // construct the messages to return if the lock is invalid.
        var lockMessages = new Dictionary<Padlocks, string>
        {
            { Padlocks.CombinationPadlock, "Invalid combination entered or Permanent Locks not allowed!" },
            { Padlocks.PasswordPadlock, "Invalid password entered or Permanent Locks not allowed!" },
            { Padlocks.TimerPadlock, "Invalid time entered!" },
            { Padlocks.TimerPasswordPadlock, "Invalid password or time entered!" },
            { Padlocks.OwnerPadlock, "Owner Locks not allowed, or pair doesn't allow permanent locks!" },
            { Padlocks.OwnerTimerPadlock, "Owner Locks not allowed, or time entered is too long!" },
            { Padlocks.DevotionalPadlock, "Devotional Locks not allowed, or pair doesn't allow permanent locks!" },
            { Padlocks.DevotionalTimerPadlock, "Devotional Locks not allowed, or time entered is too long!" }
        };

        // try and get if the validation is successful, and if not, return the message.
        if (lockValidations.TryGetValue(lockDesired, out var validation) && !validation())
            return (false, lockMessages[lockDesired]);

        // otherwise, update the lock data
        item.Padlock = lockDesired.ToName();
        item.Assigner = assigner;

        // Add timer and/or password if necessary.
        if (lockDesired.IsTimerLock()) item.Timer = GetEndTimeUTC(time);
        if (lockDesired.IsPasswordLock()) item.Password = pass;

        return (true, string.Empty);
    }


    /// <summary>
    /// A static helper method to validate the desired unlocking of a lock from an item, and if so, to apply updates to its data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item">The RestraintSet / GagLock we are trying to unlock.</param>
    /// <param name="itemOwner">The UserData of the pair we are trying to unlock this from.</param>
    /// <param name="guessedPass">the password we have guessed, if any.</param>
    /// <param name="perms">the permissions that the pair has set for us.</param>
    /// <returns>
    /// If the verification was successful, and any error string if possible. 
    /// If Valid, item will be updated with its new information to send off.
    /// </returns>
    public static (bool isValid, string logMsg) VerifyUnlock<T>(ref T item, UserData itemOwner, string guessedPass, string unlockerUID, UserPairPermissions perms) where T : IPadlockable
    {
        if (!perms.LockGags) return (false, "You don't have permission to unlock locks.");

        var padlock = item.Padlock.ToPadlock();
        if (padlock == Padlocks.None) return (false, "No padlock selected.");

        // ref the password and assigner.
        var pass = item.Password;
        var assigner = item.Assigner;

        var unlockValidations = new Dictionary<Padlocks, Func<bool>>
        {
            { Padlocks.MetalPadlock, () => true },
            { Padlocks.FiveMinutesPadlock, () => true },
            { Padlocks.TimerPadlock, () => itemOwner.UID != unlockerUID },
            { Padlocks.CombinationPadlock, () => pass == guessedPass },
            { Padlocks.PasswordPadlock, () => pass == guessedPass },
            { Padlocks.TimerPasswordPadlock, () => pass == guessedPass },
            { Padlocks.OwnerPadlock, () => itemOwner.UID == unlockerUID },
            { Padlocks.OwnerTimerPadlock, () => itemOwner.UID == unlockerUID },
            { Padlocks.DevotionalPadlock, () => itemOwner.UID == unlockerUID && itemOwner.UID == assigner },
            { Padlocks.DevotionalTimerPadlock, () => itemOwner.UID == unlockerUID && itemOwner.UID == assigner }
        };

        var unlockMessages = new Dictionary<Padlocks, string>
        {
            { Padlocks.TimerPadlock, "You can't unlock a timer padlock applied to you." },
            { Padlocks.CombinationPadlock, "Invalid combination entered." },
            { Padlocks.PasswordPadlock, "Invalid password entered." },
            { Padlocks.TimerPasswordPadlock, "Invalid password entered." },
            { Padlocks.OwnerPadlock, "You don't have permission to unlock this padlock." },
            { Padlocks.OwnerTimerPadlock, "You don't have permission to unlock this padlock." },
            { Padlocks.DevotionalPadlock, "You don't have permission to unlock this padlock." },
            { Padlocks.DevotionalTimerPadlock, "You don't have permission to unlock this padlock." }
        };

        if (unlockValidations.TryGetValue(padlock, out var validation) && !validation())
            return (false, unlockMessages[padlock]);

        // Reset the padlock data
        item.Padlock = Padlocks.None.ToName();
        item.Password = string.Empty;
        item.Timer = DateTimeOffset.MinValue;
        item.Assigner = string.Empty;

        return (true, string.Empty);
    }

    /// <summary> Validates if within allowed time. </summary>
    private static bool IsValidTime(string time, TimeSpan maxTime) => TimeSpan.TryParse(time, out var ts) && ts <= maxTime;

    /// <summary> Validates a 20 character password with no spaces </summary>
    public static bool IsValidPass(string password) => !string.IsNullOrWhiteSpace(password) && password.Length <= 20 && !password.Contains(" ");

    /// <summary> Validates a 4 digit combination </summary>
    public static bool IsValidCombo(string combination) => int.TryParse(combination, out _) && combination.Length == 4;

    public static DateTimeOffset GetEndTimeUTC(string input)
    {
        // Match days, hours, minutes, and seconds in the input string
        var match = Regex.Match(input, @"^(?:(\d+)d)?(?:(\d+)h)?(?:(\d+)m)?(?:(\d+)s)?$");

        if (match.Success)
        {
            // Parse days, hours, minutes, and seconds 
            int.TryParse(match.Groups[1].Value, out int days);
            int.TryParse(match.Groups[2].Value, out int hours);
            int.TryParse(match.Groups[3].Value, out int minutes);
            int.TryParse(match.Groups[4].Value, out int seconds);

            // Create a TimeSpan from the parsed values
            TimeSpan duration = new TimeSpan(days, hours, minutes, seconds);
            // Add the duration to the current DateTime to get a DateTimeOffset
            return DateTimeOffset.UtcNow.Add(duration);
        }

        // "Invalid duration format: {input}, returning datetimeUTCNow");
        return DateTimeOffset.UtcNow;
    }

    public static string TimeSpanToString(TimeSpan timeSpan)
    {
        var sb = new StringBuilder();
        if (timeSpan.Days > 0) sb.Append($"{timeSpan.Days}d ");
        if (timeSpan.Hours > 0) sb.Append($"{timeSpan.Hours}h ");
        if (timeSpan.Minutes > 0) sb.Append($"{timeSpan.Minutes}m ");
        if (timeSpan.Seconds > 0 || sb.Length == 0) sb.Append($"{timeSpan.Seconds}s ");
        return sb.ToString();
    }


}
