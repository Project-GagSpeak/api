using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;
public static class UpdateKindExtensions
{
    public static string ToName(this GagUpdateType kind)
    => kind switch
    {
        GagUpdateType.None => "None",
        GagUpdateType.Safeword => "Safeword",
        GagUpdateType.FullDataUpdate => "Full Data Update",
        GagUpdateType.GagApplied => "Gag Applied",
        GagUpdateType.GagLocked => "Gag Locked",
        GagUpdateType.GagUnlocked => "Gag Unlocked",
        GagUpdateType.GagRemoved => "Gag Removed",
        _ => "Unknown"
    };

    public static string ToName(this WardrobeUpdateType kind)
    => kind switch
    {
        WardrobeUpdateType.None => "None",
        WardrobeUpdateType.Safeword => "Safeword",
        WardrobeUpdateType.FullDataUpdate => "Full Data Update",
        WardrobeUpdateType.RestraintApplied => "Restraint Applied",
        WardrobeUpdateType.RestraintLocked => "Restraint Locked",
        WardrobeUpdateType.RestraintUnlocked => "Restraint Unlocked",
        WardrobeUpdateType.RestraintDisabled => "Restraint Disabled",
        WardrobeUpdateType.CursedItemApplied => "Cursed Item Applied",
        WardrobeUpdateType.CursedItemRemoved => "Cursed Item Removed",
        _ => "Unknown"
    };

    public static string ToName(this PuppeteerUpdateType kind)
    => kind switch
    {
        PuppeteerUpdateType.None => "None",
        PuppeteerUpdateType.Safeword => "Safeword",
        PuppeteerUpdateType.FullDataUpdate => "Full Data Update",
        PuppeteerUpdateType.PlayerNameRegistered => "Player Name Registered",
        PuppeteerUpdateType.AliasListUpdated => "Alias List Updated",
        _ => "Unknown"
    };

    public static string ToName(this ToyboxUpdateType kind)
    => kind switch
    {
        ToyboxUpdateType.None => "None",
        ToyboxUpdateType.Safeword => "Safeword",
        ToyboxUpdateType.FullDataUpdate => "Full Data Update",
        ToyboxUpdateType.PatternExecuted => "Pattern Executed",
        ToyboxUpdateType.PatternStopped => "Pattern Stopped",
        ToyboxUpdateType.AlarmToggled => "Alarm Toggled",
        ToyboxUpdateType.TriggerToggled => "Trigger Toggled",
        _ => "Unknown"
    };

    public static string ToName(this IpcUpdateType kind)
    => kind switch
    {
        IpcUpdateType.None => "None",
        IpcUpdateType.Safeword => "Safeword",
        IpcUpdateType.FullDataUpdate => "Full Data Update",
        IpcUpdateType.MoodlesStatusManagerChanged => "Moodles Status Manager Changed",
        IpcUpdateType.MoodlesStatusesUpdated => "Moodles Statuses Updated",
        IpcUpdateType.MoodlesPresetsUpdated => "Moodles Presets Updated",
        IpcUpdateType.MoodlesCleared => "Moodles Cleared",
        _ => "Unknown"
    };

}
