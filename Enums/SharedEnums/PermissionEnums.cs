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
public enum MoodleAccess : short
{
    None            = 0 << 0, // No Access
    AllowOwn        = 1 << 0, // The Access Owners own moodles can be applied.
    AllowOther      = 1 << 1, // The Access Owners 'other' / 'pair' can apply their moodles.
    Positive        = 1 << 2, // Positive Statuses can be applied.
    Negative        = 1 << 3, // Negative Statuses can be applied.
    Special         = 1 << 4, // Special Statuses can be applied.
    Permanent       = 1 << 5, // Moodles without a duration can be applied.
    RemoveApplied   = 1 << 6, // 'Other' can remove only moodles they have applied.
    RemoveAny       = 1 << 7, // 'Other' can remove any moodles.
    Clearing        = 1 << 8, // 'Other' can clear all moodles.
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
