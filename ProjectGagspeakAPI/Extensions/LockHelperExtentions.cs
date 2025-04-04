using GagspeakAPI.Data.Interfaces;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;
using System.Text;
using System.Text.RegularExpressions;

namespace GagspeakAPI.Extensions;

public static class PadlockValidation
{
    public static GsApiPairErrorCodes CanLock(this IPadlockable current, IPadlockable applied, TimeSpan maxTimeAllowed)
    {
        return current.Padlock switch
        {
            Padlocks.MetalPadlock => GsApiPairErrorCodes.Success,
            Padlocks.FiveMinutesPadlock => GsApiPairErrorCodes.Success,
            Padlocks.CombinationPadlock => IsValidCombo(applied.Password) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidPassword,
            Padlocks.PasswordPadlock => IsValidPass(applied.Password) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidPassword,
            Padlocks.TimerPadlock => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidTime,
            Padlocks.TimerPasswordPadlock => !IsValidLockTime(applied.Timer, maxTimeAllowed)
                ? GsApiPairErrorCodes.InvalidTime : IsValidPass(applied.Password) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidPassword,
            Padlocks.OwnerPadlock => GsApiPairErrorCodes.Success,
            Padlocks.OwnerTimerPadlock => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidTime,
            Padlocks.DevotionalPadlock => GsApiPairErrorCodes.Success,
            Padlocks.DevotionalTimerPadlock => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidTime,
            Padlocks.MimicPadlock => GsApiPairErrorCodes.Success,
            _ => GsApiPairErrorCodes.NoPadlockSelected,
        };
    }

    public static GsApiPairErrorCodes CanUnlock(this IPadlockable current, string bearerUid, string guessedPass, string enactorUid, bool allowOwner, bool allowDevotional)
    {
        return current.Padlock switch
        {
            Padlocks.MetalPadlock => GsApiPairErrorCodes.Success,
            Padlocks.FiveMinutesPadlock => GsApiPairErrorCodes.Success,
            Padlocks.CombinationPadlock => guessedPass == current.Password ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidCombination,
            Padlocks.PasswordPadlock => guessedPass == current.Password ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidPassword,
            Padlocks.TimerPadlock => bearerUid != enactorUid ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.AttemptedSelfChange,
            Padlocks.TimerPasswordPadlock => guessedPass == current.Password ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.InvalidPassword,
            Padlocks.OwnerPadlock => allowOwner ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.OwnerDenied,
            Padlocks.OwnerTimerPadlock => allowOwner ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.OwnerDenied,
            Padlocks.DevotionalPadlock => current.PadlockAssigner == enactorUid ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.DevotionalDenied,
            Padlocks.DevotionalTimerPadlock => current.PadlockAssigner == enactorUid ? GsApiPairErrorCodes.Success : GsApiPairErrorCodes.DevotionalDenied,
            _ => GsApiPairErrorCodes.NoPadlockSelected,
        };
    }

    private static bool IsValidLockTime(DateTimeOffset time, TimeSpan maxTime)
        => time - DateTimeOffset.UtcNow > maxTime;

    /// <summary> Validates if within allowed time. </summary>
    private static bool IsValidTime(string time, TimeSpan maxTime)
        => PadlockEx.TryParseTimeSpan(time, out TimeSpan ts) && ts <= maxTime;

    /// <summary> Validates a 20 character password with no spaces </summary>
    public static bool IsValidPass(string password)
        => !string.IsNullOrWhiteSpace(password) && password.Length <= 20 && !password.Contains(" ");

    /// <summary> Validates a 4 digit combination </summary>
    public static bool IsValidCombo(string combination)
        => int.TryParse(combination, out _) && combination.Length == 4;
}

public static class PadlockEx
{
    #region DefinedPadlockGroups
    public static readonly IEnumerable<Padlocks> AllLocksWithMimic = Enum.GetValues<Padlocks>();
    public static readonly IEnumerable<Padlocks> AllLocks = Enum.GetValues<Padlocks>().Where(p => p != Padlocks.MimicPadlock);
    public static readonly IEnumerable<Padlocks> ClientLocks = new[]
    {
        Padlocks.None,
        Padlocks.MetalPadlock,
        Padlocks.FiveMinutesPadlock,
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
    };

    public static readonly IEnumerable<Padlocks> TwoRowLocks = new[]
    {
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
        Padlocks.OwnerTimerPadlock,
        Padlocks.DevotionalTimerPadlock
    };

    public static readonly IEnumerable<Padlocks> PermanentLocks = new[]
    {
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.OwnerPadlock,
        Padlocks.DevotionalPadlock
    };

    public static readonly IEnumerable<Padlocks> PasswordPadlocks = new[]
    {
        Padlocks.CombinationPadlock,
        Padlocks.PasswordPadlock,
        Padlocks.TimerPasswordPadlock
    };

    public static readonly IEnumerable<Padlocks> TimerLocks = new[]
    {
        Padlocks.TimerPadlock,
        Padlocks.TimerPasswordPadlock,
        Padlocks.OwnerTimerPadlock,
        Padlocks.DevotionalTimerPadlock
    };

    public static readonly IEnumerable<Padlocks> OwnerLocks = new[]
    {
        Padlocks.OwnerPadlock,
        Padlocks.OwnerTimerPadlock
    };

    public static readonly IEnumerable<Padlocks> DevotionalLocks = new[]
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

    public static IEnumerable<Padlocks> GetLocksForPair(UserPairPermissions permissions)
    {
        HashSet<Padlocks> allowedLocks = new HashSet<Padlocks>(AllLocks);
        if (!permissions.PermanentLocks) allowedLocks.ExceptWith(PermanentLocks);
        if (!permissions.OwnerLocks) allowedLocks.ExceptWith(OwnerLocks);
        if (!permissions.DevotionalLocks) allowedLocks.ExceptWith(DevotionalLocks);
        return allowedLocks;
    }

    public static bool TryParseTimeSpan(string input, out TimeSpan result)
    {
        result = TimeSpan.Zero;
        Regex regex = new Regex(@"^\s*(?:(\d+)d\s*)?\s*(?:(\d+)h\s*)?\s*(?:(\d+)m\s*)?\s*(?:(\d+)s\s*)?$");
        Match match = regex.Match(input);

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
        Match match = Regex.Match(input, @"^\s*(?:(\d+)d\s*)?\s*(?:(\d+)h\s*)?\s*(?:(\d+)m\s*)?\s*(?:(\d+)s\s*)?$");

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
        TimeSpan timeSpan = endTime - DateTimeOffset.UtcNow;
        return timeSpan.ToGsRemainingTime();
    }

    public static string ToGsRemainingTime(this TimeSpan timeSpan)
    {
        StringBuilder sb = new StringBuilder();
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

        StringBuilder sb = new StringBuilder();
        if (remainingTime.Days > 0) sb.Append($"{remainingTime.Days}d ");
        if (remainingTime.Hours > 0) sb.Append($"{remainingTime.Hours}h ");
        if (remainingTime.Minutes > 0) sb.Append($"{remainingTime.Minutes}m ");
        if (remainingTime.Seconds > 0 || sb.Length == 0) sb.Append($"{remainingTime.Seconds}s ");
        string remainingTimeStr = sb.ToString().Trim();
        return remainingTimeStr + " left..";
    }
}