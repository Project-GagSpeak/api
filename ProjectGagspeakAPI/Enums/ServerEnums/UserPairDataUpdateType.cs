namespace GagspeakAPI.Enums;

public enum UpdateDir
{
    Own,
    Other,
}

public enum AliasType
{
    Global,
    Pair,
}

public enum DataUpdateType
{
    // Generic
    Swapped,
    Applied,
    AppliedCursed,
    LayerToggled,
    Locked,
    Unlocked,
    Removed,
    // Puppet
    NameRegistered,
    GlobalListUpdated,
    AliasListUpdated,
    // Toybox
    PatternSwitched,
    PatternExecuted,
    PatternStopped,
    AlarmToggled,
    TriggerToggled,
    // Ipc
    UpdateVisible,
    StatusManagerChanged,
    StatusesUpdated,
    PresetsUpdated,
    // Orders
    Assigned,
    Progressed,
    Completed,
    Failed,

    // Storage
    StorageUpdated,
}
