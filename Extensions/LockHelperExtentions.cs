using GagspeakAPI.Data;
using GagspeakAPI.Data.Permissions;
using GagspeakAPI.Enums;
using GagspeakAPI.Hub;
using System.Text;
using System.Text.RegularExpressions;

namespace GagspeakAPI.Extensions;

public static class PadlockValidation
{
    public static GagSpeakApiEc CanLock(this IPadlockable current, IPadlockable applied, TimeSpan maxTimeAllowed)
    {
        return applied.Padlock switch
        {
            Padlocks.Metal => GagSpeakApiEc.Success,
            Padlocks.FiveMinutes => GagSpeakApiEc.Success,
            Padlocks.Combination => IsValidCombo(applied.Password) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Password => IsValidPass(applied.Password) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Timer => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidTime,
            Padlocks.PredicamentTimer => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidTime,
            Padlocks.TimerPassword => !IsValidLockTime(applied.Timer, maxTimeAllowed)
                ? GagSpeakApiEc.InvalidTime : IsValidPass(applied.Password) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Owner => GagSpeakApiEc.Success,
            Padlocks.OwnerTimer => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidTime,
            Padlocks.Devotional => GagSpeakApiEc.Success,
            Padlocks.DevotionalTimer => IsValidLockTime(applied.Timer, maxTimeAllowed) ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidTime,
            Padlocks.Mimic => GagSpeakApiEc.Success,
            _ => GagSpeakApiEc.NullData,
        };
    }

    public static GagSpeakApiEc CanUnlock(this IPadlockable current, string bearerUid, string guessedPass, string enactorUid, bool allowOwner, bool allowDevotional)
    {
        return current.Padlock switch
        {
            Padlocks.Metal => GagSpeakApiEc.Success,
            Padlocks.FiveMinutes => GagSpeakApiEc.Success,
            Padlocks.Combination => guessedPass == current.Password ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Password => guessedPass == current.Password ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Timer => GagSpeakApiEc.Success,
            Padlocks.PredicamentTimer => bearerUid != enactorUid ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidRecipient,
            Padlocks.TimerPassword => guessedPass == current.Password ? GagSpeakApiEc.Success : GagSpeakApiEc.InvalidPassword,
            Padlocks.Owner => allowOwner ? GagSpeakApiEc.Success : GagSpeakApiEc.LackingPermissions,
            Padlocks.OwnerTimer => allowOwner ? GagSpeakApiEc.Success : GagSpeakApiEc.LackingPermissions,
            Padlocks.Devotional => current.PadlockAssigner == enactorUid ? GagSpeakApiEc.Success : GagSpeakApiEc.LackingPermissions,
            Padlocks.DevotionalTimer => current.PadlockAssigner == enactorUid ? GagSpeakApiEc.Success : GagSpeakApiEc.LackingPermissions,
            _ => GagSpeakApiEc.NullData,
        };
    }

    private static bool IsValidLockTime(DateTimeOffset time, TimeSpan maxTime)
        => (time - DateTimeOffset.UtcNow) <= maxTime;

    /// <summary> Validates if within allowed time. </summary>
    public static bool IsValidTime(string time, TimeSpan maxTime)
        => PadlockEx.TryParseTimeSpan(time, out var ts) && ts <= maxTime;

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
    public static readonly IEnumerable<Padlocks> AllLocks = Enum.GetValues<Padlocks>().Where(p => p != Padlocks.Mimic);
    public static readonly IEnumerable<Padlocks> ClientLocks = new[]
    {
        Padlocks.None,
        Padlocks.Metal,
        Padlocks.FiveMinutes,
        Padlocks.Combination,
        Padlocks.Password,
        Padlocks.Timer,
        Padlocks.PredicamentTimer,
        Padlocks.TimerPassword,
    };

    public static readonly IEnumerable<Padlocks> TwoRowLocks = new[]
    {
        Padlocks.Combination,
        Padlocks.Password,
        Padlocks.Timer,
        Padlocks.PredicamentTimer,
        Padlocks.TimerPassword,
        Padlocks.OwnerTimer,
        Padlocks.DevotionalTimer
    };

    public static readonly IEnumerable<Padlocks> PermanentLocks = new[]
    {
        Padlocks.Combination,
        Padlocks.Password,
        Padlocks.Owner,
        Padlocks.Devotional
    };

    public static readonly IEnumerable<Padlocks> PasswordPadlocks = new[]
    {
        Padlocks.Combination,
        Padlocks.Password,
        Padlocks.TimerPassword
    };

    public static readonly IEnumerable<Padlocks> TimerLocks = new[]
    {
        Padlocks.Timer,
        Padlocks.PredicamentTimer,
        Padlocks.TimerPassword,
        Padlocks.OwnerTimer,
        Padlocks.DevotionalTimer
    };

    public static readonly IEnumerable<Padlocks> OwnerLocks = new[]
    {
        Padlocks.Owner,
        Padlocks.OwnerTimer
    };

    public static readonly IEnumerable<Padlocks> DevotionalLocks = new[]
    {
        Padlocks.Devotional,
        Padlocks.DevotionalTimer
    };
    #endregion DefinedPadlockGroups

    public static bool IsTwoRowLock(this Padlocks padlock) => TwoRowLocks.Contains(padlock);
    public static bool IsPermanentLock(this Padlocks padlock) => PermanentLocks.Contains(padlock);
    public static bool IsPasswordLock(this Padlocks padlock) => PasswordPadlocks.Contains(padlock);
    public static bool IsTimerLock(this Padlocks padlock) => TimerLocks.Contains(padlock) || padlock == Padlocks.Mimic || padlock == Padlocks.FiveMinutes;
    public static bool IsOwnerLock(this Padlocks padlock) => OwnerLocks.Contains(padlock);
    public static bool IsDevotionalLock(this Padlocks padlock) => DevotionalLocks.Contains(padlock);

    public static IEnumerable<Padlocks> GetLocksForPair(PairPerms permissions)
    {
        var allowedLocks = new HashSet<Padlocks>(AllLocks);
        if (!permissions.PermanentLocks) allowedLocks.ExceptWith(PermanentLocks);
        if (!permissions.OwnerLocks) allowedLocks.ExceptWith(OwnerLocks);
        if (!permissions.DevotionalLocks) allowedLocks.ExceptWith(DevotionalLocks);
        return allowedLocks;
    }

    public static bool TryParseTimeSpan(string input, out TimeSpan result)
    {
        result = TimeSpan.Zero;

        if (input.Length is 0)
            return false;

        var regex = new Regex(@"^\s*(?:(\d+)d\s*)?\s*(?:(\d+)h\s*)?\s*(?:(\d+)m\s*)?\s*(?:(\d+)s\s*)?$");
        var match = regex.Match(input);

        if (!match.Success)
            return false;

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
