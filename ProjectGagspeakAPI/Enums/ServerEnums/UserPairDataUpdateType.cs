namespace GagspeakAPI.Enums;

public enum UpdateDir
{
    Own,
    Other,
}

public enum GagUpdateType
{
    None,
    Safeword,
    FullDataUpdate,
    GagApplied,
    GagLocked,
    GagUnlocked,
    GagRemoved,
}

public enum WardrobeUpdateType
{
    None,
    Safeword,
    FullDataUpdate,
    RestraintApplied,
    RestraintLocked,
    RestraintUnlocked,
    RestraintDisabled,
    CursedItemApplied,
    CursedItemRemoved,
}

public enum PuppeteerUpdateType
{
    None,
    Safeword,
    FullDataUpdate,
    PlayerNameRegistered,
    AliasListUpdated,
}

public enum ToyboxUpdateType
{
    None,
    Safeword,
    FullDataUpdate,
    PatternExecuted,
    PatternStopped,
    AlarmToggled,
    TriggerToggled,
}

public enum IpcUpdateType
{
    None,
    Safeword,
    FullDataUpdate,
    UpdateVisible,
    MoodlesStatusManagerChanged,
    MoodlesStatusesUpdated,
    MoodlesPresetsUpdated,
    MoodlesCleared,
}
