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

    SwitchPattern,
    StartPattern,
    StopPattern,
    ToggleAlarm,
    ToggleTrigger,
    
    ShockAction, // ???? Forgot where this happens
    VibrateAction, // ???? Forgot where this happens
    BeepAction, // ???? Forgot where this happens
    
    BulkUpdate,
    ForcedPermChange,

    ForcedEmoteState, // For the stickyPairUI only.
    
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
