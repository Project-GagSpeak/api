namespace GagspeakAPI.Enums;
public static partial class EnumToName
{
    public static string ToName(this RevertStyle revertStyle)
    => revertStyle switch
    { 
        RevertStyle.RevertToGame => "to Game",
        RevertStyle.RevertToAutomation => "to Automation",
        RevertStyle.RevertEquipToGame => "to Game State",
        RevertStyle.RevertEquipToAutomation => "to Automation",
        _ => "UNK"
    };

    public static string ToHelpText(this RevertStyle revertStyle)
    => revertStyle switch
    {
        RevertStyle.RevertToGame => "Full Appearance is reset to Base Game State.",
        RevertStyle.RevertToAutomation => "Full Appearance is reset to current Job/Gearset Automation."
        + Environment.NewLine + "- If no Automation for Job/Gearset, reverts to Base Game.",
        RevertStyle.RevertEquipToGame => "Only Gear is reset to Base Game State, while Customization is Kept.",
        RevertStyle.RevertEquipToAutomation => "Only Gear is reset to current Job/Gearset Automation, while Customization is kept."
        + Environment.NewLine + "- If no Automation for Job/Gearset, reverts to Base Game.",
        _ => "UNK"
    };



    public static string ToName(this Padlocks padlock)
    => padlock switch
    {
        Padlocks.None => "None",
        Padlocks.MetalPadlock => "Metal Padlock",
        Padlocks.CombinationPadlock => "Combination Padlock",
        Padlocks.PasswordPadlock => "Password Padlock",
        Padlocks.FiveMinutesPadlock => "5 Minutes Padlock",
        Padlocks.TimerPasswordPadlock => "Timer Password Padlock",
        Padlocks.OwnerPadlock => "Owner Padlock",
        Padlocks.OwnerTimerPadlock => "Owner Timer Padlock",
        _ => "UNK"
    };

    public static Padlocks ToPadlock(this string padlockAlias)
    => padlockAlias switch
    {
        "None" => Padlocks.None,
        "Metal Padlock" => Padlocks.MetalPadlock,
        "Combination Padlock" => Padlocks.CombinationPadlock,
        "Password Padlock" => Padlocks.PasswordPadlock,
        "5 Minutes Padlock" => Padlocks.FiveMinutesPadlock,
        "Timer Password Padlock" => Padlocks.TimerPasswordPadlock,
        "Owner Padlock" => Padlocks.OwnerPadlock,
        "Owner Timer Padlock" => Padlocks.OwnerTimerPadlock,
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


    public static string ToName(this TriggerActionType triggerActionType)
    {
        return triggerActionType switch
        {
            TriggerActionType.Vibration => "Vibration",
            TriggerActionType.PatternPlayback => "Pattern",
            _ => "UNK"
        };
    }
    public static string ToName(this TriggerActionKind triggerActionKind)
    {
        return triggerActionKind switch
        {
            TriggerActionKind.SexToy => "Sex Toy (Lovense Device)",
            TriggerActionKind.ShockCollar => "Shock Collar",
            TriggerActionKind.Restraint => "Apply Restraint",
            TriggerActionKind.Gag => "Apply Gag",
            TriggerActionKind.Moodle => "Apply Moodle",
            TriggerActionKind.MoodlePreset => "Apply Moodle Preset",
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

    public static string TriggerKindToString(this TriggerKind type)
    {
        return type switch
        {
            TriggerKind.Chat => "Chat Trigger",
            TriggerKind.SpellAction => "Action Trigger",
            TriggerKind.HealthPercent => "Health% Trigger",
            TriggerKind.RestraintSet => "Restraint Trigger",
            TriggerKind.GagState => "GagState Trigger",
            TriggerKind.SocialAction => "Social Action",
            _ => "UNK"
        };
    }

    public static string DirectionToString(this TriggerDirection type)
    {
        return type switch
        {
            TriggerDirection.Self => "From Self",
            TriggerDirection.SelfToOther => "Done onto others",
            TriggerDirection.Other => "From Others",
            TriggerDirection.OtherToSelf => "From others onto You",
            TriggerDirection.Any => "Any Filter",
            _ => "UNK"
        };
    }

    public static string EffectTypeToString(this LimitedActionEffectType type)
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
            LimitedActionEffectType.Interrupt => "Interrupt Applied",
            _ => "UNK"
        };
    }

    public static string ToName(this LoggerType type)
    {
        return type switch
        {
            LoggerType.None => "None",
            LoggerType.Achievements => "Achievements",
            LoggerType.Mediator => "Mediator",
            LoggerType.IpcGagSpeak => "Ipc Provider",
            LoggerType.IpcCustomize => "Customize+",
            LoggerType.IpcGlamourer => "Glamourer",
            LoggerType.IpcMare => "Mare",
            LoggerType.IpcMoodles => "Moodles",
            LoggerType.IpcPenumbra => "Penumbra",

            LoggerType.HardcoreActions => "Actions",
            LoggerType.HardcoreMovement => "Movements",
            LoggerType.HardcorePrompt => "Prompts",

            LoggerType.GarblerCore => "GarblerCore",

            LoggerType.GagManagement => "Gag Handling",
            LoggerType.PadlockManagement => "Padlock Handling",

            LoggerType.ClientPlayerData => "Client Data",
            LoggerType.GameObjects => "Game Objects",
            LoggerType.PairManagement => "Pair Handling",
            LoggerType.OnlinePairs => "Online Pairs",
            LoggerType.VisiblePairs => "Visible Pairs",
            LoggerType.PrivateRoom => "Private Rooms",

            LoggerType.Notification => "Notifications",
            LoggerType.Profiles => "Profiles",
            LoggerType.Cosmetics => "Cosmetics",
            LoggerType.GlobalChat => "Global Chat",
            LoggerType.ContextDtr => "Context DTR",
            LoggerType.PatternHub => "Pattern Hub",
            LoggerType.Safeword => "Safeword",

            LoggerType.Restraints => "Restraints",
            LoggerType.Puppeteer => "Puppeteer",

            LoggerType.ToyboxDevices => "Devices",
            LoggerType.ToyboxPatterns => "Patterns",
            LoggerType.ToyboxTriggers => "Triggers",
            LoggerType.ToyboxAlarms => "Alarms",
            LoggerType.VibeControl => "Vibe Control",

            LoggerType.ChatDetours => "Chat Detours",
            LoggerType.ActionEffects => "Action Effects",
            LoggerType.SpatialAudioController => "Spatial Audio",
            LoggerType.SpatialAudioLogger => "Spatial Logger",

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
