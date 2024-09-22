using GagspeakAPI.Data;
using GagspeakAPI.Data.Character;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Helpers;

// some ToString overrides used for certain DTO's to help avoid adding too much content to the transfer items.

public static class ToStringHelpers
{
    public static string ParseToString(this CharacterToyboxData data)
    {
        string result = "Parsed Information:\n";
        result += "Patterns:\n";
        foreach (var pattern in data.PatternList)
        {
            result += pattern.ParseToString() + "\n";
        }
        result += "Triggers:\n";
        foreach (var trigger in data.TriggerList)
        {
            result += trigger.ParseToString() + "\n";
        }
        result += "Alarms:\n";
        foreach (var alarm in data.AlarmList)
        {
            result += alarm.ParseToString() + "\n";
        }
        return result;
    }

    public static string ParseToString(this PatternInfo data)
    {
        string result = ">> ";
        result += $"[Name:: {data.Name}]";
        result += $"[Desc:: {data.Description}]";
        result += $"[Length:: {data.Duration}]";
        result += $"[Loops?:: {data.ShouldLoop}]";
        return result;
    }

    public static string ParseToString(this TriggerInfo data)
    {
        string result = ">> ";
        result += $"[Enabled:: {data.Enabled}]";
        result += $"[Name:: {data.Name}]";
        result += $"[Desc:: {data.Description}]";

        switch (data.Type)
        {
            case TriggerKind.Chat:
                result += "[Type:: Chat Message]";
                break;
            case TriggerKind.SpellAction:
                result += "[Type:: Action]";
                break;
            case TriggerKind.HealthPercent:
                result += "[Type:: On HP]";
                break;
            case TriggerKind.RestraintSet:
                result += "[Type:: On Restraint]";
                break;
            case TriggerKind.GagState:
                result += "[Type:: On Gag]";
                break;
            case TriggerKind.SocialAction:
                result += "[Type:: On Social Act]";
                break;
        }
        result += $"[User Access:: " + string.Join(',', data.CanViewAndToggleTrigger) + "]";
        return result;
    }

    public static string ParseToString(this AlarmInfo data)
    {
        string result = ">> ";
        result += $"[Name:: {data.Name}]";
        result += $"[Enabled:: {data.Enabled}]";
        result += $"[Time (UTC):: {data.SetTimeUTC}]";
        result += $"[Pattern:: {data.PatternToPlay}]";
        result += $"[Length:: {data.PatternDuration}]";
        result += $"[Days Set:: " + string.Join(',', data.RepeatFrequency) + "]";
        return result;
    }


}
