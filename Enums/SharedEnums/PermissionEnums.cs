namespace GagspeakAPI.Enums;


[Flags]
public enum PuppetPerms : byte
{
    None   = 0x00, //   no actions are allowed.
    Sit    = 0x01, //   /sit, /groundsit, /cpose allowed.
    Emotes = 0x02, //   any emote is allowed.
    Alias  = 0x04, //   alias actions enabled can be used.
    All    = 0x08, //   all actions are allowed.
}

[Flags]
public enum MoodlePerms : byte
{
    None                          = 0x00, //   no actions are allowed.
    PositiveStatusTypes           = 0x01, //   positive status types are allowed.
    NegativeStatusTypes           = 0x02, //   negative status types are allowed.
    SpecialStatusTypes            = 0x04, //   special status types are allowed.
    PairCanApplyTheirMoodlesToYou = 0x08, //   pair can apply own moodles to you.
    PairCanApplyYourMoodlesToYou  = 0x10, //   pair can apply your moodles to you.
    PermanentMoodles              = 0x20, //   permanent moodles are allowed.
    RemovingMoodles               = 0x40, //   moodles can be removed.
}

public enum PermissionType
{
    Global,     // Use GlobalPerms & PairEditAccess
    Hardcore,   // Use HardcoreState & PairPerms
    PairPerm,   // Use UniquePairPerms & PairEditAccess
    PairAccess, // Used to validate the edit access checkbox catagory, not used in sensarios.
};

public enum PresetName : byte
{
    NoneSelected,
    Dominant,
    Brat,
    RopeBunny,
    Submissive,
    Slut,
    Pet,
    Slave,
    OwnersSlut,
    OwnersPet,
    OwnersSlave
};

public enum InteractionsTab
{
    None,
    KinkstersPerms,
    PermsForKinkster,
    Interactions,
}
