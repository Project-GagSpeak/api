using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace GagspeakAPI.Extensions;

public static class GsPadlockEx
{
    #region DefinedPadlockGroups
    public static readonly HashSet<Padlocks> AllLocksWithMimic = Enum.GetValues<Padlocks>().ToHashSet();
    public static readonly HashSet<Padlocks> AllLocks = Enum.GetValues<Padlocks>().Where(p => p != Padlocks.MimicPadlock).ToHashSet();
    public static readonly HashSet<Padlocks> ClientLocks = new()
    {
        Padlocks.None,
        Padlocks.MetalPadlock,
        Padlocks.FiveMinutesPadlock,
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
    };

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
        Padlocks.CombinationPadlock,
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
    #endregion DefinedPadlockGroups

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
        var allowedLocks = new HashSet<Padlocks>(AllLocks);
        if (!permissions.PermanentLocks) allowedLocks.ExceptWith(PermanentLocks);
        if (!permissions.OwnerLocks) allowedLocks.ExceptWith(OwnerLocks);
        if (!permissions.DevotionalLocks) allowedLocks.ExceptWith(DevotionalLocks);
        return allowedLocks;
    }

    public static string ToFlagString(this PadlockReturnCode errorCode)
    {
        List<string> flagNames = new List<string>();
        // Iterate over each power of 2 (bit flags)
        foreach (PadlockReturnCode flag in Enum.GetValues(typeof(PadlockReturnCode)))
        {
            // Skip the "None" flag, as it indicates no flags are set
            if (flag == PadlockReturnCode.Success) continue;

            // Check if the flag is set using bitwise AND
            if ((errorCode & flag) == flag) flagNames.Add(flag.ToString());
        }
        return flagNames.Count > 0 ? string.Join(", ", flagNames) : PadlockReturnCode.Success.ToString();
    }

    /// <summary>
    /// Static helper for validating Padlock Locking action. Recommend passing in deep clone of data, as it is modified inside the function if valid.
    /// </summary>
    /// <returns>
    /// If the verification was successful, and any error string if possible. 
    /// If Valid, item will be updated with its new information to send off.
    /// </returns>
    public static PadlockReturnCode VerifyLock<T>(ref T item, Padlocks lockDesired, string pass, string time, string assignerUID, UserPairPermissions? perms = null) where T : IPadlockable
    {
        var maxLockTime = perms is not null ? GetMaxLockTime(item, perms) : TimeSpan.MaxValue;
        var validationResult = ValidateLock(lockDesired, pass, time, maxLockTime, perms);

        // return the error if any was given.
        if (validationResult != PadlockReturnCode.Success)
            return validationResult;

        // otherwise, update the lock data
        item.Padlock = lockDesired.ToName();
        item.Timer = lockDesired.IsTimerLock() ? (lockDesired is Padlocks.FiveMinutesPadlock ? DateTimeOffset.UtcNow.AddMinutes(5) : time.GetEndTimeUTC()) : DateTimeOffset.UtcNow;
        item.Password = lockDesired.IsPasswordLock() ? pass : string.Empty;
        item.Assigner = assignerUID;
        return PadlockReturnCode.Success;
    }

    public static PadlockReturnCode VerifyUnlock<T>(ref T item, UserData itemOwner, string guessedPass, string unlockerUID, UserPairPermissions? perms = null) where T : IPadlockable
    {
        var validationResult = ValidateUnlock(item, itemOwner, guessedPass, unlockerUID, perms);

        // return the error if any was given.
        if (validationResult != PadlockReturnCode.Success)
            return validationResult;

        // otherwise, update the lock data
        item.Padlock = Padlocks.None.ToName();
        item.Timer = DateTimeOffset.MinValue;
        item.Password = string.Empty;
        item.Assigner = string.Empty;
        return PadlockReturnCode.Success;
    }

    /// <summary>
    /// Helper function for the pair-based lock validation.
    /// </summary>
    /// <returns>
    /// The maximum allowed time for timer padlocks.
    /// </returns>
    public static TimeSpan GetMaxLockTime<T>(T item, UserPairPermissions perms) where T : IPadlockable
    {
        // Determine the max lock time based on the item type.
        if (item is CharaWardrobeData) return perms.MaxAllowedRestraintTime;
        if (item is GagSlot) return perms.MaxGagTime;
        return TimeSpan.Zero;
    }

    public static PadlockReturnCode ValidateLock(Padlocks lockDesired, string pass, string time, TimeSpan maxLockTime, UserPairPermissions? perms = null)
    {
        var returnCode = PadlockReturnCode.Success;

        // append returned flags based on the validation.
        if (lockDesired is Padlocks.None) 
            return returnCode |= PadlockReturnCode.NoPadlockSelected;

        var validationRules = new Dictionary<Padlocks, Func<PadlockReturnCode>>
        {
            { Padlocks.MetalPadlock, () => PadlockReturnCode.Success },
            { Padlocks.FiveMinutesPadlock, () => PadlockReturnCode.Success },
            { Padlocks.CombinationPadlock, () =>
                !IsValidCombo(pass) ? PadlockReturnCode.InvalidCombination :
                (perms != null && !perms.PermanentLocks) ? PadlockReturnCode.PermanentRestricted : PadlockReturnCode.Success },
            { Padlocks.PasswordPadlock, () =>
                !IsValidPass(pass) ? PadlockReturnCode.InvalidPassword :
                (perms != null && !perms.PermanentLocks) ? PadlockReturnCode.PermanentRestricted : PadlockReturnCode.Success },
            { Padlocks.TimerPadlock, () =>
                !IsValidTime(time, maxLockTime) ? PadlockReturnCode.InvalidTime : PadlockReturnCode.Success },
            { Padlocks.TimerPasswordPadlock, () =>
                !IsValidPass(pass) ? PadlockReturnCode.InvalidPassword :
                !IsValidTime(time, maxLockTime) ? PadlockReturnCode.InvalidTime : PadlockReturnCode.Success },
            { Padlocks.OwnerPadlock, () =>
                perms == null ? PadlockReturnCode.OwnerRestricted :
                !perms.OwnerLocks ? PadlockReturnCode.OwnerRestricted :
                !perms.PermanentLocks ? PadlockReturnCode.PermanentRestricted : PadlockReturnCode.Success },
            { Padlocks.OwnerTimerPadlock, () =>
                perms == null ? PadlockReturnCode.OwnerRestricted :
                !perms.OwnerLocks ? PadlockReturnCode.OwnerRestricted :
                !IsValidTime(time, maxLockTime) ? PadlockReturnCode.InvalidTime : PadlockReturnCode.Success },
            { Padlocks.DevotionalPadlock, () =>
                perms == null ? PadlockReturnCode.DevotionalRestricted :
                !perms.DevotionalLocks ? PadlockReturnCode.DevotionalRestricted :
                !perms.PermanentLocks ? PadlockReturnCode.PermanentRestricted : PadlockReturnCode.Success },
            { Padlocks.DevotionalTimerPadlock, () =>
                perms == null ? PadlockReturnCode.DevotionalRestricted :
                !perms.DevotionalLocks ? PadlockReturnCode.DevotionalRestricted :
                !IsValidTime(time, maxLockTime) ? PadlockReturnCode.InvalidTime : PadlockReturnCode.Success }
        };

        // Check if validation rules exist for the padlock and return the corresponding error code
        if (validationRules.TryGetValue(lockDesired, out var validate)) 
            returnCode = validate();

        return returnCode;
    }

    public static PadlockReturnCode ValidateUnlock<T>(T item, UserData itemOwner, string guessedPass, string unlockerUID, UserPairPermissions? perms = null) where T : IPadlockable
    {
        var returnCode = PadlockReturnCode.Success;

        if (item is CharaWardrobeData && perms is not null && !perms.UnlockRestraintSets) 
            return returnCode |= PadlockReturnCode.UnlockingRestricted;
        
        if (item is GagSlot && perms is not null && !perms.UnlockGags) 
            return returnCode |= PadlockReturnCode.UnlockingRestricted;

        var validationRules = new Dictionary<Padlocks, Func<PadlockReturnCode>>
        {
            { Padlocks.MetalPadlock, () => PadlockReturnCode.Success },
            { Padlocks.FiveMinutesPadlock, () => PadlockReturnCode.Success },
            { Padlocks.TimerPadlock, () =>
                itemOwner.UID == unlockerUID ? PadlockReturnCode.UnlockingRestricted : PadlockReturnCode.Success },
            { Padlocks.CombinationPadlock, () =>
                item.Password != guessedPass ? PadlockReturnCode.InvalidCombination : PadlockReturnCode.Success },
            { Padlocks.PasswordPadlock, () =>
                item.Password != guessedPass ? PadlockReturnCode.InvalidPassword : PadlockReturnCode.Success },
            { Padlocks.TimerPasswordPadlock, () =>
                item.Password != guessedPass ? PadlockReturnCode.InvalidPassword : PadlockReturnCode.Success },
            { Padlocks.OwnerPadlock, () =>
                perms is null ? PadlockReturnCode.OwnerRestricted :
                !perms.OwnerLocks ? PadlockReturnCode.OwnerRestricted : PadlockReturnCode.Success },
            { Padlocks.OwnerTimerPadlock, () =>
                perms is null ? PadlockReturnCode.OwnerRestricted :
                !perms.OwnerLocks ? PadlockReturnCode.OwnerRestricted : PadlockReturnCode.Success },
            { Padlocks.DevotionalPadlock, () =>
                perms is null ? PadlockReturnCode.DevotionalRestricted :
                !perms.DevotionalLocks ? PadlockReturnCode.DevotionalRestricted :
                item.Assigner != unlockerUID ? PadlockReturnCode.NotLockAssigner : PadlockReturnCode.Success },
            { Padlocks.DevotionalTimerPadlock, () =>
                perms is null ? PadlockReturnCode.DevotionalRestricted :
                !perms.DevotionalLocks ? PadlockReturnCode.DevotionalRestricted :
                item.Assigner != unlockerUID ? PadlockReturnCode.NotLockAssigner : PadlockReturnCode.Success }
        };

        // Check if validation rules exist for the padlock and return the corresponding error code
        if (validationRules.TryGetValue(item.Padlock.ToPadlock(), out var validate)) 
            returnCode = validate();

        return returnCode;
    }

    /// <summary> Validates if within allowed time. </summary>
    private static bool IsValidTime(string time, TimeSpan maxTime) => TryParseTimeSpan(time, out var ts) && ts <= maxTime;

    /// <summary> Validates a 20 character password with no spaces </summary>
    public static bool IsValidPass(string password) => !string.IsNullOrWhiteSpace(password) && password.Length <= 20 && !password.Contains(" ");

    /// <summary> Validates a 4 digit combination </summary>
    public static bool IsValidCombo(string combination) => int.TryParse(combination, out _) && combination.Length == 4;


    public static bool TryParseTimeSpan(string input, out TimeSpan result)
    {
        result = TimeSpan.Zero;
        var regex = new Regex(@"^\s*(?:(\d+)d\s*)?\s*(?:(\d+)h\s*)?\s*(?:(\d+)m\s*)?\s*(?:(\d+)s\s*)?$");
        var match = regex.Match(input);

        if (!match.Success)
        {
            return false;
        }

        int days = match.Groups[1].Success ? int.Parse(match.Groups[1].Value) : 0;
        int hours = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 0;
        int minutes = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 0;
        int seconds = match.Groups[4].Success ? int.Parse(match.Groups[4].Value) : 0;

        result = new TimeSpan(days, hours, minutes, seconds);
        return true;
    }

    public static DateTimeOffset GetEndTimeUTC(this string input)
    {
        // Match days, hours, minutes, and seconds in the input string
        var match = Regex.Match(input, @"^\s*(?:(\d+)d\s*)?\s*(?:(\d+)h\s*)?\s*(?:(\d+)m\s*)?\s*(?:(\d+)s\s*)?$");

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

    public static string GetEndTimeOffsetString(this DateTimeOffset endTime)
    {
        var timeSpan = endTime - DateTimeOffset.UtcNow;
        return timeSpan.ToGsRemainingTime();
    }

    public static string ToGsRemainingTime(this TimeSpan timeSpan)
    {
        var sb = new StringBuilder();
        if (timeSpan.Days > 0) sb.Append($"{timeSpan.Days}d ");
        if (timeSpan.Hours > 0) sb.Append($"{timeSpan.Hours}h ");
        if (timeSpan.Minutes > 0) sb.Append($"{timeSpan.Minutes}m ");
        if (timeSpan.Seconds > 0 || sb.Length == 0) sb.Append($"{timeSpan.Seconds}s ");
        return sb.ToString();
    }

    public static string ToGsRemainingTimeFancy(this DateTimeOffset lockEndTime)
    {
        TimeSpan remainingTime = (lockEndTime - DateTimeOffset.UtcNow);
        // if the remaining timespan is not a negative value, output the time.
        if (remainingTime.TotalSeconds <= 0)
            return "Expired";

        var sb = new StringBuilder();
        if (remainingTime.Days > 0) sb.Append($"{remainingTime.Days}d ");
        if (remainingTime.Hours > 0) sb.Append($"{remainingTime.Hours}h ");
        if (remainingTime.Minutes > 0) sb.Append($"{remainingTime.Minutes}m ");
        if (remainingTime.Seconds > 0 || sb.Length == 0) sb.Append($"{remainingTime.Seconds}s ");
        string remainingTimeStr = sb.ToString().Trim();
        return remainingTimeStr + " left..";
    }


}
