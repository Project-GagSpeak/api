using GagspeakAPI.Data.Enum;
using GagspeakAPI.Data.VibeServer;

public static class EnumNameExtensions
{
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


    public static GagType ToGagType(this string alias) => alias switch
    {
        "Ball Gag" => GagType.BallGag,
        "Ball Gag Mask" => GagType.BallGagMask,
        "Bamboo Gag" => GagType.BambooGag,
        "Belt Strap Gag" => GagType.BeltStrapGag,
        "Bit Gag" => GagType.BitGag,
        "Bit Gag Padded" => GagType.BitGagPadded,
        "Bone Gag" => GagType.BoneGag,
        "Bone Gag (XL)" => GagType.BoneGagXL,
        "Candle Gag" => GagType.CandleGag,
        "Cage Muzzle" => GagType.CageMuzzle,
        "Cleave Gag" => GagType.CleaveGag,
        "Chloroform Gag" => GagType.ChloroformGag,
        "Chopstick Gag" => GagType.ChopStickGag,
        "Cloth Wrap Gag" => GagType.ClothWrapGag,
        "Cloth Stuffing Gag" => GagType.ClothStuffingGag,
        "Crop Gag" => GagType.CropGag,
        "Cup Holder Gag" => GagType.CupHolderGag,
        "Deepthroat Penis Gag" => GagType.DeepthroatPenisGag,
        "Dental Gag" => GagType.DentalGag,
        "Dildo Gag" => GagType.DildoGag,
        "Duct Tape Gag" => GagType.DuctTapeGag,
        "Duster Gag" => GagType.DusterGag,
        "Funnel Gag" => GagType.FunnelGag,
        "Futuristic Harness Ball Gag" => GagType.FuturisticHarnessBallGag,
        "Futuristic Harness Panel Gag" => GagType.FuturisticHarnessPanelGag,
        "Gas Mask" => GagType.GasMask,
        "Harness Ball Gag" => GagType.HarnessBallGag,
        "Harness Ball Gag XL" => GagType.HarnessBallGagXL,
        "Harness Panel Gag" => GagType.HarnessPanelGag,
        "Hook Gag Mask" => GagType.HookGagMask,
        "Inflatable Hood" => GagType.InflatableHood,
        "Large Dildo Gag" => GagType.LargeDildoGag,
        "Latex Hood" => GagType.LatexHood,
        "Latex Ball Muzzle Gag" => GagType.LatexBallMuzzleGag,
        "Latex Posture Collar Gag" => GagType.LatexPostureCollarGag,
        "Leather Corset Collar Gag" => GagType.LeatherCorsetCollarGag,
        "Leather Hood" => GagType.LeatherHood,
        "Lip Gag" => GagType.LipGag,
        "Medical Mask" => GagType.MedicalMask,
        "Muzzle Gag" => GagType.MuzzleGag,
        "Panty Stuffing Gag" => GagType.PantyStuffingGag,
        "Plastic Wrap Gag" => GagType.PlasticWrapGag,
        "Plug Gag" => GagType.PlugGag,
        "Pony Gag" => GagType.PonyGag,
        "Pump Gag Lv.1" => GagType.PumpGaglv1,
        "Pump Gag Lv.2" => GagType.PumpGaglv2,
        "Pump Gag Lv.3" => GagType.PumpGaglv3,
        "Pump Gag Lv.4" => GagType.PumpGaglv4,
        "Ribbon Gag" => GagType.RibbonGag,
        "Ring Gag" => GagType.RingGag,
        "Rope Gag" => GagType.RopeGag,
        "Scarf Gag" => GagType.ScarfGag,
        "Sensory Deprivation Hood" => GagType.SensoryDeprivationHood,
        "Sock Stuffing Gag" => GagType.SockStuffingGag,
        "Spider Gag" => GagType.SpiderGag,
        "Tentacle Gag" => GagType.TenticleGag,
        "Web Gag" => GagType.WebGag,
        "Wiffle Gag" => GagType.WiffleGag,
        "None" => GagType.None,
        _ => GagType.None
    };

    public static string GagName(this GagType gagType)
        => AliasToGagTypeMap.FirstOrDefault(x => x.Value == gagType).Key;


    public static readonly Dictionary<string, GagType> AliasToGagTypeMap = new()
    {
        { "Ball Gag", GagType.BallGag },
        { "Ball Gag Mask", GagType.BallGagMask },
        { "Bamboo Gag", GagType.BambooGag },
        { "Belt Strap Gag", GagType.BeltStrapGag },
        { "Bit Gag", GagType.BitGag },
        { "Bit Gag Padded", GagType.BitGagPadded },
        { "Bone Gag", GagType.BoneGag },
        { "Bone Gag (XL)", GagType.BoneGagXL },
        { "Candle Gag", GagType.CandleGag },
        { "Cage Muzzle", GagType.CageMuzzle },
        { "Cleave Gag", GagType.CleaveGag },
        { "Chloroform Gag", GagType.ChloroformGag },
        { "Chopstick Gag", GagType.ChopStickGag },
        { "Cloth Wrap Gag", GagType.ClothWrapGag },
        { "Cloth Stuffing Gag", GagType.ClothStuffingGag },
        { "Crop Gag", GagType.CropGag },
        { "Cup Holder Gag", GagType.CupHolderGag },
        { "Deepthroat Penis Gag", GagType.DeepthroatPenisGag },
        { "Dental Gag", GagType.DentalGag },
        { "Dildo Gag", GagType.DildoGag },
        { "Duct Tape Gag", GagType.DuctTapeGag },
        { "Duster Gag", GagType.DusterGag },
        { "Funnel Gag", GagType.FunnelGag },
        { "Futuristic Harness Ball Gag", GagType.FuturisticHarnessBallGag },
        { "Futuristic Harness Panel Gag", GagType.FuturisticHarnessPanelGag },
        { "Gas Mask", GagType.GasMask },
        { "Harness Ball Gag", GagType.HarnessBallGag },
        { "Harness Ball Gag XL", GagType.HarnessBallGagXL },
        { "Harness Panel Gag", GagType.HarnessPanelGag },
        { "Hook Gag Mask", GagType.HookGagMask },
        { "Inflatable Hood", GagType.InflatableHood },
        { "Large Dildo Gag", GagType.LargeDildoGag },
        { "Latex Hood", GagType.LatexHood },
        { "Latex Ball Muzzle Gag", GagType.LatexBallMuzzleGag },
        { "Latex Posture Collar Gag", GagType.LatexPostureCollarGag },
        { "Leather Corset Collar Gag", GagType.LeatherCorsetCollarGag },
        { "Leather Hood", GagType.LatexHood },
        { "Lip Gag", GagType.LipGag },
        { "Medical Mask", GagType.MedicalMask },
        { "Muzzle Gag", GagType.MuzzleGag },
        { "Panty Stuffing Gag", GagType.PantyStuffingGag },
        { "Plastic Wrap Gag", GagType.PlasticWrapGag },
        { "Plug Gag", GagType.PlugGag },
        { "Pony Gag", GagType.PonyGag },
        { "Pump Gag Lv.1", GagType.PumpGaglv1 },
        { "Pump Gag Lv.2", GagType.PumpGaglv2 },
        { "Pump Gag Lv.3", GagType.PumpGaglv3 },
        { "Pump Gag Lv.4", GagType.PumpGaglv4 },
        { "Ribbon Gag", GagType.RibbonGag },
        { "Ring Gag", GagType.RingGag },
        { "Rope Gag", GagType.RopeGag },
        { "Scarf Gag", GagType.ScarfGag },
        { "Sensory Deprivation Hood", GagType.SensoryDeprivationHood },
        { "Sock Stuffing Gag", GagType.SockStuffingGag },
        { "Spider Gag", GagType.SpiderGag },
        { "Tentacle Gag", GagType.TenticleGag },
        { "Web Gag", GagType.WebGag },
        { "Wiffle Gag", GagType.WiffleGag },
        { "None", GagType.None },
    };
}
