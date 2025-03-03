// AttackType from ReceiveActionEffect calls.
// https://github.com/NightmareXIV/ECommons/blob/master/ECommons/Hooks/ActionEffectTypes/AttackType.cs

namespace GagspeakAPI.Enums;

public enum InteractionType
{
    None,
    SwappedRestraint,
    ApplyRestraint,
    LockRestraint,
    UnlockRestraint,
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
    
    ForcedFollow,
    ForcedEmoteState,
    ForcedStay,
    ForcedChatVisibility,
    ForcedChatInputVisibility,
    ForcedChatInputBlock,
    ForcedPermChange,
    
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
