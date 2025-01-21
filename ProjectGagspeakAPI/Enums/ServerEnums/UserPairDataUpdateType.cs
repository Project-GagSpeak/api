namespace GagspeakAPI.Enums;

public enum UpdateDir
{
    Own,
    Other,
}

public enum GagUpdateType
{
    Applied,
    AppliedCursed,
    Locked,
    Unlocked,
    Removed,
}

public enum WardrobeUpdateType
{
    Applied,
    Locked,
    Unlocked,
    Disabled,
}

public enum OrdersUpdateType
{
    FullUpdate,
    Added,
    Assigned,
    Progressed,
    Completed,
    Failed,
    Removed,
}

public enum PuppeteerUpdateType
{
    FullUpdate,
    PlayerNameRegistered,
    AliasListUpdated,
}

public enum ToyboxUpdateType
{
    PatternExecuted,
    PatternStopped,
    AlarmToggled,
    TriggerToggled,
}

public enum IpcUpdateType
{
    FullUpdate,
    UpdateVisible,
    StatusManagerChanged,
    StatusesUpdated,
    PresetsUpdated,
    ClearedMoodles,
}
