using GagspeakAPI.Enums;

namespace GagspeakAPI.Extensions;
public static class UpdateKindExtensions
{
    public static string ToName(this GagUpdateType kind)
    => kind switch
    {
        GagUpdateType.Applied => "Gag Applied",
        GagUpdateType.Locked => "Gag Locked",
        GagUpdateType.Unlocked => "Gag Unlocked",
        GagUpdateType.Removed => "Gag Removed",
        _ => "Unknown"
    };

    public static string ToName(this WardrobeUpdateType kind)
    => kind switch
    {
        WardrobeUpdateType.Applied => "Restraint Applied",
        WardrobeUpdateType.Locked => "Restraint Locked",
        WardrobeUpdateType.Unlocked => "Restraint Unlocked",
        WardrobeUpdateType.Disabled => "Restraint Disabled",
        _ => "Unknown"
    };

    public static string ToName(this PuppeteerUpdateType kind)
    => kind switch
    {
        PuppeteerUpdateType.PlayerNameRegistered => "Player Name Registered",
        PuppeteerUpdateType.AliasListUpdated => "Alias List Updated",
        _ => "Unknown"
    };

    public static string ToName(this ToyboxUpdateType kind)
    => kind switch
    {
        ToyboxUpdateType.PatternExecuted => "Pattern Executed",
        ToyboxUpdateType.PatternStopped => "Pattern Stopped",
        ToyboxUpdateType.AlarmToggled => "Alarm Toggled",
        ToyboxUpdateType.TriggerToggled => "Trigger Toggled",
        _ => "Unknown"
    };

    public static string ToName(this IpcUpdateType kind)
    => kind switch
    {
        IpcUpdateType.FullUpdate => "Full Data Update",
        IpcUpdateType.UpdateVisible => "Update Visible",
        IpcUpdateType.StatusManagerChanged => "Moodles Status Manager Changed",
        IpcUpdateType.StatusesUpdated => "Moodles Statuses Updated",
        IpcUpdateType.PresetsUpdated => "Moodles Presets Updated",
        IpcUpdateType.ClearedMoodles => "Moodles Cleared",
        _ => "Unknown"
    };

}
