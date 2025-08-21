using GagspeakAPI.Attributes;

namespace GagspeakAPI.Enums;

public enum InteractionType
{
    None,
    SwappedRestraint,
    SwappedRestraintLayers,
    ApplyRestraint,
    ApplyRestraintLayers,
    LockRestraint,
    UnlockRestraint,
    RemoveRestraintLayers,
    RemoveRestraint,
    
    SwappedRestriction,
    ApplyRestriction,
    LockRestriction,
    UnlockRestriction,
    RemoveRestriction,

    SwappedGag,
    ApplyGag,
    LockGag,
    UnlockGag,
    RemoveGag,

    ApplyCollar,
    UpdateCollar,
    RemoveCollar,

    ApplyPairMoodle,
    ApplyPairMoodlePreset,
    ApplyOwnMoodle,
    ApplyOwnMoodlePreset,
    RemoveMoodle,
    ClearMoodle,

    ListenerName,
    AliasList,
    GlobalTrigger,
    PairTrigger,

    HypnosisEffect,

    SwitchPattern,
    StartPattern,
    StopPattern,
    ToggleAlarm,
    ToggleTrigger,
    
    ShockAction,
    VibrateAction,
    BeepAction,
    
    BulkUpdate,
    ForcedPermChange,
    HardcoreStateChange,

    // Hardcore State Changes (For Interactions Menu)
    LockedFollow,
    LockedEmoteState,
    Confinement,
    Imprisonment,
    ChatBoxHiding,
    ChatInputHiding,
    ChatInputBlocking,

    VibeControl,
    PiShockUpdate,
}

public enum InteractionFilter
{
    All,
    Applier,
    Interaction,
    Content,
}
