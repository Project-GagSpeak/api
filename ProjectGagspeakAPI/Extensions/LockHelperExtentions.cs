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
        var flagNames = new List<string>();
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

    public static PadlockReturnCode ValidateLockUpdate<T>(T item, Padlocks lockDesired, string pass, string time, UserPairPermissions? perms = null) where T : IPadlockableRestriction
    {
        var maxLockTime = perms is not null ? GetMaxLockTime(item, perms) : TimeSpan.MaxValue;
        return ValidateLock(lockDesired, pass, time, maxLockTime, perms?.PermanentLocks ?? true, perms?.OwnerLocks ?? false, perms?.DevotionalLocks ?? false);
    }

    public static void PerformLockUpdate<T>(ref T padlockItem, Padlocks lockType, string pass, string time, string enactorUid) where T : IPadlockableRestriction
    {
        padlockItem.Padlock = lockType;
        padlockItem.Timer = lockType.IsTimerLock() ? time.GetEndTimeUTC() : DateTimeOffset.UtcNow;
        padlockItem.Password = lockType.IsPasswordLock() ? pass : string.Empty;
        padlockItem.PadlockAssigner = enactorUid;
    }

    public static PadlockReturnCode ValidateUnlockUpdate<T>(T item, UserData itemOwner, string guessedPass, string enactorUid, UserPairPermissions? perms = null) where T : IPadlockableRestriction
    {
        return ValidateUnlock(item, itemOwner, guessedPass, enactorUid, perms?.OwnerLocks ?? false, perms?.DevotionalLocks ?? false);
    }

    public static void PerformUnlockUpdate<T>(ref T padlockItem) where T : IPadlockableRestriction
    {
        padlockItem.Padlock = Padlocks.None;
        padlockItem.Timer = DateTimeOffset.MinValue;
        padlockItem.Password = string.Empty;
        padlockItem.PadlockAssigner = string.Empty;
    }

    public static TimeSpan GetMaxLockTime<T>(T item, UserPairPermissions perms) where T : IPadlockableRestriction
    {
        // Determine the max lock time based on the item type.
        if (item is CharaActiveRestraint) return perms.MaxRestraintTime;
        if (item is CharaActiveRestrictions) return perms.MaxRestrictionTime;
        if (item is CharaActiveGags) return perms.MaxGagTime;
        return TimeSpan.Zero;
    }

    public static PadlockReturnCode ValidateCombinationPadlock(string combination, bool allowsPermanent)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!IsValidCombo(combination)) returnCode |= PadlockReturnCode.InvalidCombination;
        if (!allowsPermanent) returnCode |= PadlockReturnCode.PermanentRestricted;
        return returnCode;
    }

    public static PadlockReturnCode ValidatePasswordPadlock(string password, bool allowsPermanent)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!IsValidPass(password)) returnCode |= PadlockReturnCode.InvalidPassword;
        if (!allowsPermanent) returnCode |= PadlockReturnCode.PermanentRestricted;
        return returnCode;
    }

    public static PadlockReturnCode ValidateTimerPadlock(string time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!IsValidTime(time, maxTime)) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateTimerPadlock(DateTimeOffset time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (time - DateTimeOffset.UtcNow > maxTime) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidatePasswordTimerPadlock(string password, string time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!IsValidPass(password)) returnCode |= PadlockReturnCode.InvalidPassword;
        if (!IsValidTime(time, maxTime)) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidatePasswordTimerPadlock(string password, DateTimeOffset time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!IsValidPass(password)) returnCode |= PadlockReturnCode.InvalidPassword;
        if (time - DateTimeOffset.UtcNow > maxTime) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateOwnerPadlock(bool allowOwner, bool allowPermanent)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowOwner) returnCode |= PadlockReturnCode.OwnerRestricted;
        if (!allowPermanent) returnCode |= PadlockReturnCode.PermanentRestricted;
        return returnCode;
    }

    public static PadlockReturnCode ValidateOwnerTimerPadlock(bool allowOwner, string time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowOwner) returnCode |= PadlockReturnCode.OwnerRestricted;
        if (!IsValidTime(time, maxTime)) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateOwnerTimerPadlock(bool allowOwner, DateTimeOffset time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowOwner) returnCode |= PadlockReturnCode.OwnerRestricted;
        if (time - DateTimeOffset.UtcNow > maxTime) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateDevotionalPadlock(bool allowDevotional, bool allowPermanent)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowDevotional) returnCode |= PadlockReturnCode.DevotionalRestricted;
        if (!allowPermanent) returnCode |= PadlockReturnCode.PermanentRestricted;
        return returnCode;
    }

    public static PadlockReturnCode ValidateDevotionalTimerPadlock(bool allowDevotional, string time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowDevotional) returnCode |= PadlockReturnCode.DevotionalRestricted;
        if (!IsValidTime(time, maxTime)) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateDevotionalTimerPadlock(bool allowDevotional, DateTimeOffset time, TimeSpan maxTime)
    {
        var returnCode = PadlockReturnCode.Success;
        if (!allowDevotional) returnCode |= PadlockReturnCode.DevotionalRestricted;
        if (time - DateTimeOffset.UtcNow > maxTime) returnCode |= PadlockReturnCode.InvalidTime;
        return returnCode;
    }

    public static PadlockReturnCode ValidateLock(Padlocks lockDesired, string pass, string time, TimeSpan maxLockTime, bool allowPermanent, bool allowOwner, bool allowDevotional)
    {
        var returnCode = PadlockReturnCode.Success;

        // append returned flags based on the validation.
        if (lockDesired is Padlocks.None) 
            return returnCode |= PadlockReturnCode.NoPadlockSelected;

        var validationRules = new Dictionary<Padlocks, Func<PadlockReturnCode>>
        {
            { Padlocks.MetalPadlock, () => PadlockReturnCode.Success },
            { Padlocks.FiveMinutesPadlock, () => PadlockReturnCode.Success },
            { Padlocks.CombinationPadlock, () => ValidateCombinationPadlock(pass, allowPermanent) },
            { Padlocks.PasswordPadlock, () => ValidatePasswordPadlock(pass, allowPermanent) },
            { Padlocks.TimerPadlock, () => ValidateTimerPadlock(time, maxLockTime) },
            { Padlocks.TimerPasswordPadlock, () => ValidatePasswordTimerPadlock(pass, time, maxLockTime) },
            { Padlocks.OwnerPadlock, () => ValidateOwnerPadlock(allowOwner, allowPermanent) },
            { Padlocks.OwnerTimerPadlock, () => ValidateOwnerTimerPadlock(allowOwner, time, maxLockTime) },
            { Padlocks.DevotionalPadlock, () => ValidateDevotionalPadlock(allowDevotional, allowPermanent) },
            { Padlocks.DevotionalTimerPadlock, () => ValidateDevotionalTimerPadlock(allowDevotional, time, maxLockTime) }
        };

        // Check if validation rules exist for the padlock and return the corresponding error code
        if (validationRules.TryGetValue(lockDesired, out var validate)) 
            returnCode = validate();

        return returnCode;
    }

    public static PadlockReturnCode ValidateUnlock<T>(T item, UserData itemOwner, string guessedPass, string enactorUid, bool allowOwner, bool allowDevotional) where T : IPadlockableRestriction
    {
        var returnCode = PadlockReturnCode.Success;

        // Handle automatic unlocks.
        if (item.Timer - DateTimeOffset.UtcNow < TimeSpan.FromSeconds(5))
            return returnCode;

        var validationRules = new Dictionary<Padlocks, Func<PadlockReturnCode>>
        {
            { Padlocks.MetalPadlock, () => PadlockReturnCode.Success },
            { Padlocks.FiveMinutesPadlock, () => PadlockReturnCode.Success },
            { Padlocks.TimerPadlock, () => itemOwner.UID == enactorUid ? PadlockReturnCode.UnlockingRestricted : PadlockReturnCode.Success },
            { Padlocks.CombinationPadlock, () => item.Password != guessedPass ? PadlockReturnCode.InvalidCombination : PadlockReturnCode.Success },
            { Padlocks.PasswordPadlock, () => item.Password != guessedPass ? PadlockReturnCode.InvalidPassword : PadlockReturnCode.Success },
            { Padlocks.TimerPasswordPadlock, () => item.Password != guessedPass ? PadlockReturnCode.InvalidPassword : PadlockReturnCode.Success },
            { Padlocks.OwnerPadlock, () => allowOwner ? PadlockReturnCode.Success : PadlockReturnCode.OwnerRestricted },
            { Padlocks.OwnerTimerPadlock, () => allowOwner ? PadlockReturnCode.Success : PadlockReturnCode.OwnerRestricted },
            { Padlocks.DevotionalPadlock, () => !allowDevotional 
                ? PadlockReturnCode.DevotionalRestricted : item.PadlockAssigner != enactorUid 
                    ? PadlockReturnCode.NotLockAssigner : PadlockReturnCode.Success },
            { Padlocks.DevotionalTimerPadlock, () => !allowDevotional 
                ? PadlockReturnCode.DevotionalRestricted : item.PadlockAssigner != enactorUid 
                    ? PadlockReturnCode.NotLockAssigner : PadlockReturnCode.Success }
        };

        // Check if validation rules exist for the padlock and return the corresponding error code
        if (validationRules.TryGetValue(item.Padlock, out var validate)) 
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

        var days = match.Groups[1].Success ? int.Parse(match.Groups[1].Value) : 0;
        var hours = match.Groups[2].Success ? int.Parse(match.Groups[2].Value) : 0;
        var minutes = match.Groups[3].Success ? int.Parse(match.Groups[3].Value) : 0;
        var seconds = match.Groups[4].Success ? int.Parse(match.Groups[4].Value) : 0;

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
            int.TryParse(match.Groups[1].Value, out var days);
            int.TryParse(match.Groups[2].Value, out var hours);
            int.TryParse(match.Groups[3].Value, out var minutes);
            int.TryParse(match.Groups[4].Value, out var seconds);

            // Create a TimeSpan from the parsed values
            var duration = new TimeSpan(days, hours, minutes, seconds);
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
        var remainingTime = (lockEndTime - DateTimeOffset.UtcNow);
        // if the remaining timespan is not a negative value, output the time.
        if (remainingTime.TotalSeconds <= 0)
            return "Expired";

        var sb = new StringBuilder();
        if (remainingTime.Days > 0) sb.Append($"{remainingTime.Days}d ");
        if (remainingTime.Hours > 0) sb.Append($"{remainingTime.Hours}h ");
        if (remainingTime.Minutes > 0) sb.Append($"{remainingTime.Minutes}m ");
        if (remainingTime.Seconds > 0 || sb.Length == 0) sb.Append($"{remainingTime.Seconds}s ");
        var remainingTimeStr = sb.ToString().Trim();
        return remainingTimeStr + " left..";
    }


}
