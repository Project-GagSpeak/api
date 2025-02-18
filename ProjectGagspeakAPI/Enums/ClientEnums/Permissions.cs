namespace GagspeakAPI.Enums;

// flags enum for the kind of permissions given.
[Flags]
public enum PuppeteerPerms
{
    None    = 0x00, //   no actions are allowed.
    Sit     = 0x01, //   /sit, /groundsit, /cpose allowed.
    Emotes  = 0x02, //   any emote is allowed.
    Alias   = 0x04, //   alias actions enabled can be used.
    All     = 0x08, //   all actions are allowed.
}



public enum PermissionType 
{
    Global,                   // Use GlobalPerms & PairPermEditAccess
    UniquePairPerm,           // Use UniquePairPerms & PairPermEditAccess
    UniquePairPermEditAccess, // Used to validate the edit access checkbox catagory, not used in sensarios.
    Hardcore                  // Special case where Action is GlobalPerm, and edit access is UniquePairPerm
};

public enum PermissionValueType
{
    YesNo,
    TimeSpan,
    String,
    TimeSpanSliderInt,
};

public enum PresetName : byte
{
    NoneSelected,
    Dominant,
    Brat,                // give no permissions, but allow light punishment.
    RopeBunny,           // Perfect for those looking to have some fun getting tied and gagged.
    Submissive,          // Perfect for light play or one night stands.
    Slut,                // Grants pair no access perms, but opens up general range of fun.
    Pet,                 // Grants pair no access perms, opens short locks and some actions.
    Slave,               // Grants pair no access perms, opens long locks and most actions.
    OwnersSlut,
    OwnersPet,
    OwnersSlave
};

public enum StickyWindowType
{
    None,
    PairPerms,
    ClientPermsForPair,
    PairActionFunctions,
}


