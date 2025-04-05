namespace GagspeakAPI.Enums;
public static partial class EnumToName
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
        Padlocks.MetalPadlock => "Metal Padlock",
        Padlocks.FiveMinutesPadlock => "5 Minutes Padlock",
        Padlocks.CombinationPadlock => "Combination Padlock",
        Padlocks.PasswordPadlock => "Password Padlock",
        Padlocks.TimerPadlock => "Timer Padlock",
        Padlocks.TimerPasswordPadlock => "Timer Password Padlock",
        Padlocks.OwnerPadlock => "Owner Padlock",
        Padlocks.OwnerTimerPadlock => "Owner Timer Padlock",
        Padlocks.DevotionalPadlock => "Devotional Padlock",
        Padlocks.DevotionalTimerPadlock => "Devotional Timer Padlock",
        Padlocks.MimicPadlock => "Mimic Padlock",
        _ => "UNK"
    };

    public static Padlocks ToPadlock(this string padlockAlias)
    => padlockAlias switch
    {
        "None" => Padlocks.None,
        "Metal Padlock" => Padlocks.MetalPadlock,
        "5 Minutes Padlock" => Padlocks.FiveMinutesPadlock,
        "Combination Padlock" => Padlocks.CombinationPadlock,
        "Password Padlock" => Padlocks.PasswordPadlock,
        "Timer Padlock" => Padlocks.TimerPadlock,
        "Timer Password Padlock" => Padlocks.TimerPasswordPadlock,
        "Owner Padlock" => Padlocks.OwnerPadlock,
        "Owner Timer Padlock" => Padlocks.OwnerTimerPadlock,
        "Devotional Padlock" => Padlocks.DevotionalPadlock,
        "Devotional Timer Padlock" => Padlocks.DevotionalTimerPadlock,
        "Mimic Padlock" => Padlocks.MimicPadlock,
        // handle outdated calls where they were translated by ToString()
        "MetalPadlock" => Padlocks.MetalPadlock,
        "CombinationPadlock" => Padlocks.CombinationPadlock,
        "PasswordPadlock" => Padlocks.PasswordPadlock,
        "FiveMinutesPadlock" => Padlocks.FiveMinutesPadlock,
        "TimerPasswordPadlock" => Padlocks.TimerPasswordPadlock,
        "OwnerPadlock" => Padlocks.OwnerPadlock,
        "OwnerTimerPadlock" => Padlocks.OwnerTimerPadlock,
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
        InteractionType.ApplyRestraint => "Restraint Applied",
        InteractionType.LockRestraint => "Restraint Locked",
        InteractionType.UnlockRestraint => "Restraint Unlocked",
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
        InteractionType.ForcedFollow => "Forced Follow",
        InteractionType.ForcedEmoteState => "Forced Emote State",
        InteractionType.ForcedStay => "Forced Stay",
        InteractionType.ForcedChatVisibility => "Chat Visibility",
        InteractionType.ForcedChatInputVisibility => "Chat Input Visibility",
        InteractionType.ForcedChatInputBlock => "Chat Input Block",        
        InteractionType.ForcedPermChange => "Forced Perm Change",
        InteractionType.VibeControl => "Vibe Control",
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
            InvokableActionType.SexToy => "Sex Toy",
            InvokableActionType.ShockCollar => "Shock Collar",
            InvokableActionType.Restraint => "Apply Restraint",
            InvokableActionType.Gag => "Apply Gag",
            InvokableActionType.Moodle => "Apply Moodle",
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
            TriggerKind.SpellAction => "Action Trigger",
            TriggerKind.HealthPercent => "Health% Trigger",
            TriggerKind.RestraintSet => "Restraint Trigger",
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

    public static string ToName(this LimitedActionEffectType type)
    {
        return type switch
        {
            LimitedActionEffectType.Miss => "Action Missed",
            LimitedActionEffectType.Damage => "Damage Related",
            LimitedActionEffectType.Heal => "Heal Related",
            LimitedActionEffectType.BlockedDamage => "Damage Blocked",
            LimitedActionEffectType.ParriedDamage => "Damage Parried",
            LimitedActionEffectType.Attract1 => "Rescue Used",
            LimitedActionEffectType.Knockback => "Pushed Back",
            _ => "UNK"
        };
    }

    public static string ToName(this LoggerType type)
    {
        return type switch
        {
            LoggerType.None => "None",
            LoggerType.Achievements => "Achievements",
            LoggerType.AchievementEvents => "Events",
            LoggerType.AchievementInfo => "Achievement Info",

            LoggerType.IpcGagSpeak => "Ipc Provider",
            LoggerType.IpcCustomize => "Customize+",
            LoggerType.IpcGlamourer => "Glamourer",
            LoggerType.IpcMare => "Mare",
            LoggerType.IpcMoodles => "Moodles",
            LoggerType.IpcPenumbra => "Penumbra",

            LoggerType.AppearanceState => "Appearance",
            LoggerType.ToyboxState => "Toybox",
            LoggerType.Mediator => "Mediator",
            LoggerType.GarblerCore => "GarblerCore",

            LoggerType.ToyboxAlarms => "Alarms",
            LoggerType.ActionsNotifier => "Actions Notifier",
            LoggerType.KinkPlateMonitor => "KinkPlates™",
            LoggerType.EmoteMonitor => "Emote Monitor",
            LoggerType.ChatDetours => "Chat Detours",
            LoggerType.ActionEffects => "Action Effects",
            LoggerType.SpatialAudioLogger => "Spatial Logger",

            LoggerType.HardcoreActions => "Actions",
            LoggerType.HardcoreMovement => "Movements",
            LoggerType.HardcorePrompt => "Prompts",

            LoggerType.ClientPlayerData => "Client Data",
            LoggerType.GagHandling => "Gag Handling",
            LoggerType.PadlockHandling => "Padlock Handling",
            LoggerType.Restraints => "Restraints",
            LoggerType.Puppeteer => "Puppeteer",
            LoggerType.CursedLoot => "Cursed Loot",
            LoggerType.ToyboxDevices => "Devices",
            LoggerType.ToyboxPatterns => "Patterns",
            LoggerType.ToyboxTriggers => "Triggers",
            LoggerType.VibeControl => "Vibe Control",

            LoggerType.PairManagement => "Pair Management",
            LoggerType.PairInfo => "Pair Info",
            LoggerType.PairDataTransfer => "Pair Data",
            LoggerType.PairHandlers => "Pair Handlers",
            LoggerType.OnlinePairs => "Online Pairs",
            LoggerType.VisiblePairs => "Visible Pairs",
            LoggerType.VibeRooms => "Vibe Rooms",
            LoggerType.GameObjects => "Game Objects",

            LoggerType.Cosmetics => "Cosmetics",
            LoggerType.Textures => "Textures",
            LoggerType.GlobalChat => "Global Chat",
            LoggerType.ContextDtr => "Context DTR",
            LoggerType.PatternHub => "Pattern Hub",
            LoggerType.Safeword => "Safeword",

            LoggerType.UiCore => "UI Core",
            LoggerType.UserPairDrawer => "User Pair Drawer",
            LoggerType.Permissions => "Permissions",
            LoggerType.Simulation => "Simulation",

            LoggerType.PiShock => "PiShock",
            LoggerType.ApiCore => "API Core",
            LoggerType.Callbacks => "Callbacks",
            LoggerType.Health => "Health",
            LoggerType.HubFactory => "Hub Factory",
            LoggerType.JwtTokens => "JWT Tokens",
            _ => "UNK"
        };
    }
}
