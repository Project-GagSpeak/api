namespace GagspeakAPI.Enums;

// Maybe Diversify this more later idk.
public enum AchievementModuleKind
{
    Generic,
    Gags,
    Wardrobe,
    Puppeteer,
    Toybox,
    Remotes,
    Arousal,
    Hardcore,
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
    ConditionalThreshold,
    TimeLimitConditional,
    RequiredTimeConditional, // formerly conditional duration
}

public enum UnlocksEvent
{
    // Restraints lowest priority
    RestraintUpdated, // for dye changes
    RestraintStateChange,
    PairRestraintStateChange,
    RestraintLayerChange,
    PairRestraintLayerChange,
    RestraintLockChange,
    PairRestraintLockChange,

    // Restrictions 2nd priority
    RestrictionStateChange,
    PairRestrictionStateChange,
    RestrictionLockStateChange,
    PairRestrictionLockStateChange,

    // Gags 3rd priority
    GagStateChange,
    PairGagStateChange,
    GagLockStateChange,
    PairGagLockStateChange,
    GagUnlockGuessFailed,

    PuppeteerAccessGiven, // true == all permissions, false == emote permissions. (yes, im lazy)
    PuppeteerOrderSent, // when you make another pair execute an emote.
    PuppeteerEmoteRecieved, // when you recieve an emote order from another pair.
    PuppeteerOrderRecieved, // when you recieve an order from another pair.

    PatternAction,
    DeviceConnected,
    TriggerFired,
    DeathRollCompleted,
    ShockSent,
    ShockReceived,
    AlarmToggled,
    PvpPlayerSlain,
    ClientSlain,
    ClientOneHp,

    HardcoreAction,

    RemoteOpened,
    VibeRoomCreated,

    VibratorsToggled,

    // Generic
    ChatMessageSent, // chat type, message, and sender.
    EmoteExecuted, // contains emote used in string value.
    TutorialCompleted,
    PairAdded,
    PresetApplied,
    GlobalSent,
    CursedDungeonLootFound,
    ChocoboRaceFinished,
    PlayersInProximity,
    CutsceneInturrupted,

    // Special
    SoldSlave,
    AuctionedOff,
}

public enum PuppeteerMsgType
{
    GenericOrder,
    GrovelOrder,
    SulkOrder,
    DanceOrder,
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

public enum PatternInteractionKind
{
    Published,
    Downloaded,
    Liked,
    Started,
    Stopped,
}
