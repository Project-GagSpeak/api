// AttackType from ReceiveActionEffect calls.
// https://github.com/NightmareXIV/ECommons/blob/master/ECommons/Hooks/ActionEffectTypes/AttackType.cs

namespace GagspeakAPI.Enums;

public enum ActiveActionButton
{
    None,
    ApplyGag,
    LockGag,
    UnlockGag,
    RemoveGag,
    ApplyRestraint,
    LockRestraint,
    UnlockRestraint,
    RemoveRestraint,
    ApplyPairMoodle,
    ApplyPairMoodlePreset,
    ApplyOwnMoodle,
    ApplyOwnMoodlePreset,
    RemoveMoodle,
    ClearMoodle,
    ToggleAlarm,
    ActivatePattern,
    StopPattern,
    ToggleTrigger,
    ShockAction,
    VibrateAction,
    BeepAction
}
