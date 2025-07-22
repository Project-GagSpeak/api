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
    LayersChanged,
    LayersApplied,
    LayersRemoved,
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

    // Storage
    StorageUpdated,
}
