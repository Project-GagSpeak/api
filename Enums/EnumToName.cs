using GagspeakAPI.Attributes;

namespace GagspeakAPI.Enums;
public static class EnumToName
{
    public static string ToName(this DurationLength duration)
    => duration switch
    {
        DurationLength.Any => "Any Time",
        DurationLength.Tiny => "≤ 1min",
        DurationLength.Short => "≤ 5min",
        DurationLength.Medium => "5-20min",
        DurationLength.Long => "≤ 1hour",
        DurationLength.ExtraLong => "≥ 1hour",
        _ => "UNK"
    };

    public static string ToName(this InteractionFilter filterKind)
    => filterKind switch
    {
        InteractionFilter.All => "All",
        InteractionFilter.Applier => "Nick/Alias/UID",
        InteractionFilter.Interaction => "Interaction Type",
        InteractionFilter.Content => "Content Details",
        _ => "UNK"
    };

    public static string ToName(this Padlocks padlock)
    => padlock switch
    {
        Padlocks.None => "None",
        Padlocks.Metal => "Metal Padlock",
        Padlocks.FiveMinutes => "5 Minutes Padlock",
        Padlocks.Combination => "Combination Padlock",
        Padlocks.Password => "Password Padlock",
        Padlocks.Timer => "Timer Padlock",
        Padlocks.PredicamentTimer => "Predicament Timer Padlock",
        Padlocks.TimerPassword => "Timer Password Padlock",
        Padlocks.Owner => "Owner Padlock",
        Padlocks.OwnerTimer => "Owner Timer Padlock",
        Padlocks.Devotional => "Devotional Padlock",
        Padlocks.DevotionalTimer => "Devotional Timer Padlock",
        Padlocks.Mimic => "Mimic Padlock",
        _ => "UNK"
    };

    public static Padlocks ToPadlock(this string padlockAlias)
    => padlockAlias switch
    {
        "None" => Padlocks.None,
        "Metal Padlock" => Padlocks.Metal,
        "5 Minutes Padlock" => Padlocks.FiveMinutes,
        "Combination Padlock" => Padlocks.Combination,
        "Password Padlock" => Padlocks.Password,
        "Timer Padlock" => Padlocks.Timer,
        "Predicament Timer Padlock" => Padlocks.PredicamentTimer,
        "Timer Password Padlock" => Padlocks.TimerPassword,
        "Owner Padlock" => Padlocks.Owner,
        "Owner Timer Padlock" => Padlocks.OwnerTimer,
        "Devotional Padlock" => Padlocks.Devotional,
        "Devotional Timer Padlock" => Padlocks.DevotionalTimer,
        "Mimic Padlock" => Padlocks.Mimic,

        // handle outdated calls where they were translated by ToString() (can likely remove, idk)
        "Metal" => Padlocks.Metal,
        "Combination" => Padlocks.Combination,
        "Password" => Padlocks.Password,
        "FiveMinutes" => Padlocks.FiveMinutes,
        "TimerPassword" => Padlocks.TimerPassword,
        "Owner" => Padlocks.Owner,
        "OwnerTimer" => Padlocks.OwnerTimer,
        _ => Padlocks.None
    };

    public static string ToName(this InteractionType interactionType)
    => interactionType switch
    {
        InteractionType.None => "None",
        InteractionType.SwappedGag => "Gag Swapped",
        InteractionType.ApplyGag => "Gag Applied",
        InteractionType.LockGag => "Gag Locked",
        InteractionType.UnlockGag => "Gag Unlocked",
        InteractionType.RemoveGag => "Gag Removed",
        InteractionType.SwappedRestriction => "Restriction Swapped",
        InteractionType.ApplyRestriction => "Restriction Applied",
        InteractionType.LockRestriction => "Restriction Locked",
        InteractionType.UnlockRestriction => "Restriction Unlocked",
        InteractionType.RemoveRestriction => "Restriction Removed",
        InteractionType.SwappedRestraint=> "Restraint Swapped",
        InteractionType.SwappedRestraintLayers => "Restraint Layers Swapped",
        InteractionType.ApplyRestraint => "Restraint Applied",
        InteractionType.ApplyRestraintLayers => "Restraint Layers Applied",
        InteractionType.LockRestraint => "Restraint Locked",
        InteractionType.UnlockRestraint => "Restraint Unlocked",
        InteractionType.RemoveRestraintLayers => "Restraint Layers Removed",
        InteractionType.RemoveRestraint => "Restraint Removed",
        InteractionType.ApplyPairMoodle => "Moodle Applied",
        InteractionType.ApplyPairMoodlePreset => "Moodle Preset Applied",
        InteractionType.ApplyOwnMoodle => "Moodle Applied",
        InteractionType.ApplyOwnMoodlePreset => "Moodle Preset Applied",
        InteractionType.RemoveMoodle => "Moodle Removed",
        InteractionType.ClearMoodle => "Moodle Cleared",
        InteractionType.ToggleAlarm => "Alarm Toggled",
        InteractionType.SwitchPattern => "Pattern Switched",
        InteractionType.StartPattern => "Pattern Started",
        InteractionType.StopPattern => "Pattern Stopped",
        InteractionType.ToggleTrigger => "Trigger Toggled",
        InteractionType.ShockAction => "Shock Action",
        InteractionType.VibrateAction => "Vibrate Action",
        InteractionType.BeepAction => "Beep Action",
        InteractionType.BulkUpdate => "Bulk Update",        
        InteractionType.ForcedPermChange => "Forced Perm Change",
        InteractionType.VibeControl => "Vibe Control",
        _ => "UNK"
    };

    public static string ToName(this Arousal arousal)
    => arousal switch
    {
        Arousal.None => "No Arousal",
        Arousal.Weak => "Weak Arousal",
        Arousal.Light => "Light Arousal",
        Arousal.Mild => "Mild Arousal",
        Arousal.Strong => "Strong Arousal",
        _ => "UNK"
    };

    public static string ToName(this Precedence precedence)
    => precedence switch
    {
        Precedence.VeryLow  => "Lowest",
        Precedence.Low      => "Low",
        Precedence.Default  => "Normal",
        Precedence.High     => "High",
        Precedence.Highest  => "Highest",
        _ => "UNK"
    };

    public static string ToName(this InvokableActionType triggerActionKind)
    {
        return triggerActionKind switch
        {
            InvokableActionType.TextOutput => "Text Output",
            InvokableActionType.Gag => "Gag Action",
            InvokableActionType.Restriction => "Restriction Action",
            InvokableActionType.Restraint => "Restraint Action",
            InvokableActionType.Moodle => "Moodle Action",
            InvokableActionType.ShockCollar => "Shock Action",
            InvokableActionType.SexToy => "SexToy Action",
            _ => "UNK"
        };
    }

    public static string ToName(this PresetName preset)
    {
        return preset switch
        {
            PresetName.NoneSelected => "None",
            PresetName.Dominant => "Dominant",
            PresetName.Brat => "Brat",
            PresetName.RopeBunny => "Rope Bunny",
            PresetName.Submissive => "Submissive",
            PresetName.Slut => "Slut",
            PresetName.Pet => "Pet",
            PresetName.Slave => "Slave",
            PresetName.OwnersSlut => "Owner's Slut",
            PresetName.OwnersPet => "Owner's Pet",
            PresetName.OwnersSlave => "Owner's Slave",
            _ => "UNK"
        };
    }

    public static string ToName(this TriggerKind type)
    {
        return type switch
        {
            TriggerKind.SpellAction => "Spell / Action Trigger",
            TriggerKind.HealthPercent => "Health% Trigger",
            TriggerKind.RestraintSet => "Restraint State Trigger",
            TriggerKind.Restriction => "Restriction State Trigger",
            TriggerKind.GagState => "GagState Trigger",
            TriggerKind.SocialAction => "Social Action",
            TriggerKind.EmoteAction => "Emote Action",
            _ => "UNK"
        };
    }

    public static string ToName(this TriggerDirection type)
    {
        return type switch
        {
            TriggerDirection.Self => "From Self",
            TriggerDirection.SelfToOther => "From you to others",
            TriggerDirection.Other => "From Others",
            TriggerDirection.OtherToSelf => "From others to You",
            TriggerDirection.Any => "Any Filter",
            _ => "UNK"
        };
    }

    public static string ToName(this HypnoAttributes attribute)
    {
        return attribute switch
        {
            HypnoAttributes.TextDisplayOrdered  => "Sequential phrases",
            HypnoAttributes.TextDisplayRandom   => "Randomized phrases",
            HypnoAttributes.LinearTextScale     => "Text scales up",
            HypnoAttributes.RandomTextScale     => "Text scales randomly",
            HypnoAttributes.TextFade            => "Text fades in & out",
            HypnoAttributes.InvertDirection     => "Invert spin",
            HypnoAttributes.SpeedUpOnCycle      => "Speedup inbetween",
            HypnoAttributes.TransposeColors     => "Color Transpose",
            HypnoAttributes.ArousalScalesSpeed  => "Arousal integration",
            HypnoAttributes.ArousalPulsesText   => "Arousal pulses text",
            _ => "UNK"
        };
    }

    public static string ToCompactName(this HypnoAttributes attribute)
    {
        return attribute switch
        {
            HypnoAttributes.TextDisplayOrdered => "Sequential",
            HypnoAttributes.TextDisplayRandom => "Randomized",
            HypnoAttributes.LinearTextScale => "Growing",
            HypnoAttributes.RandomTextScale => "Randomized",
            HypnoAttributes.TextFade => "Text Fades",
            HypnoAttributes.InvertDirection => "Invert Spin",
            HypnoAttributes.SpeedUpOnCycle => "Accel Between",
            HypnoAttributes.TransposeColors => "Color Transpose",
            HypnoAttributes.ArousalScalesSpeed => "Embed Arousal",
            HypnoAttributes.ArousalPulsesText => "Arousal Pulse",
            _ => "UNK"
        };
    }

    public static string ToTooltip(this  HypnoAttributes attribute)
    {
        return attribute switch
        {
            HypnoAttributes.TextDisplayOrdered => "Phrases display in the containers order.",
            HypnoAttributes.TextDisplayRandom => "Phrases will display in a random order.",
            HypnoAttributes.LinearTextScale => "Phrases will gradually grow during their display lifetime.",
            HypnoAttributes.RandomTextScale => "Phrases will appear at randomized scales.",
            HypnoAttributes.TextFade => "Phrases fade in and out at the start and end of display lifetime.",
            HypnoAttributes.InvertDirection => "Spins counter-clockwise instead of clockwise.",
            HypnoAttributes.SpeedUpOnCycle => "Briefly accelerates spin speed between display phases.",
            HypnoAttributes.TransposeColors => "Continuously phase between the set color and its inverse.",
            HypnoAttributes.ArousalScalesSpeed => "Display phrase speed can be amplified by arousal rate",
            HypnoAttributes.ArousalPulsesText => "Arousal can cause the text phrases to pulsate.",
            _ => "UNK"
        };
    }
}
