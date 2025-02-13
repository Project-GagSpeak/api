namespace GagspeakAPI.Enums;

public enum UpdateDir
{
    Own,
    Other,
}

public enum DataUpdateType
{
    // Generic
    Swapped = 0,
    Applied = 1,
    AppliedCursed = 2,
    Locked = 3,
    Unlocked = 4,
    Removed = 5,
    // Puppet
    NameRegistered = 6,
    AliasListUpdated = 7,
    // Toybox
    PatternSwitched = 8,
    PatternExecuted = 9,
    PatternStopped = 10,
    AlarmToggled = 11,
    TriggerToggled = 12,
    // Ipc
    UpdateVisible = 13,
    StatusManagerChanged = 14,
    StatusesUpdated = 15,
    PresetsUpdated = 16,
    // Orders
    Assigned = 18,
    Progressed = 19,
    Completed = 20,
    Failed = 21,

    // Storage
    StorageUpdated = 22,
}
