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
    ConditionalThreshold,
    TimeLimitConditional,
    RequiredTimeConditional, // formerly conditional duration
}

public enum UnlocksEvent
{
    OrderAction, // for finished, failed, and created actions.

    // Contains the layer, type, assigner.
    GagStateChange,
    PairGagStateChange,
    GagLockStateChange,
    PairGagLockStateChange,
    GagUnlockGuessFailed,

    RestraintUpdated, // for dye changes
    RestraintStateChange,
    PairRestraintStateChange,
    RestraintLockChange,
    PairRestraintLockChange,

    RestrictionStateChange,
    PairRestrictionStateChange,
    RestrictionLockStateChange,
    PairRestrictionLockStateChange,

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

    // For certain achievements requiring special conditions
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

public enum OrderInteractionKind
{
    Create,
    Started,
    Completed,
    Fail,
}
