namespace GagspeakAPI.Enums;

public enum AchievementModuleKind
{
    Orders,
    Gags,
    Wardrobe,
    Puppeteer,
    Toybox,
    Hardcore,
    Remotes,
    Generic,
    Secrets,
}

public enum AchievementType
{
    Progress, 
    Duration,
    Conditional,
    Threshold,
    TimedProgress,
    ConditionalProgress,
    TimeLimitConditional,
    RequiredTimeConditional, // formerly conditional duration


}

public enum UnlocksEvent
{
    OrderAction, // for finished, failed, and created actions.
    
    GagAction, // Contains the layer, type, and if it was self applied.
    PairGagAction,
    GagUnlockGuessFailed,
    GagRemoval,

    RestraintUpdated, // for dye changes
    RestraintApplicationChanged,
    PairRestraintApplied,
    RestraintLockChange,
    PairRestraintLockChange,

    PuppeteerMessageSend,
    PuppeteerAccessGiven, // true == all permissions, false == emote permissions. (yes, im lazy)

    PatternAction,
    DeviceConnected,
    TriggerFired,
    DeathRollCompleted,
    ShockSent,
    ShockReceived,
    AlarmToggled,
    PvpPlayerSlain,
    ClientSlain,

    HardcoreForcedPairAction,

    RemoteOpened,
    VibeRoomCreated,

    //////// Generics & Secrets Below /////////
    ChatMessageSent, // chat type, message, and sender.
    PuppeteerEmoteSent, // emote used in string value.
    EmoteExecuted, // contains emote used in string value.
    TutorialCompleted,
    PairAdded,
    PresetApplied,
    GlobalSent,
    CursedDungeonLootFound,
    EasterEggFound,
    ChocoboRaceFinished,
    PlayersInProximity,

}

public enum DurationTimeUnit
{
    Seconds,
    Minutes,
    Hours,
    Days
}
public enum DeepDungeonType
{
    Unknown,
    PalaceOfTheDead,
    HeavenOnHigh,
    EurekaOrthos,
}

public enum HardcorePairActionKind
{
    ForcedFollow,
    ForcedSit,
    ForcedStay,
    ForcedBlindfold,
}

public enum PatternInteractionKind
{
    Published,
    Downloaded,
    Liked,
    Started,
    Stopped,
}

public enum OrderInteractionKind
{
    Create,
    Started,
    Completed,
    Fail,
}
