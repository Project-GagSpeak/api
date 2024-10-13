namespace GagspeakAPI.Enums;

public enum LoggerType
{
    None,
    Achievements,
    Mediator,
    // interop
    IpcGagSpeak,
    IpcCustomize,
    IpcGlamourer,
    IpcMare,
    IpcMoodles,
    IpcPenumbra,
    Appearance,
    // hardcore
    HardcoreActions,
    HardcoreMovement,
    HardcorePrompt,
    // MuffleCore
    GarblerCore,
    // PlayerData
    GagManagement,
    PadlockManagement,
    ClientPlayerData,
    GameObjects,
    PairManagement,
    OnlinePairs,
    VisiblePairs,
    PrivateRoom,
    // services
    Notification,
    Profiles,
    Cosmetics,
    GlobalChat,
    ContextDtr,
    PatternHub,
    Safeword,
    CursedLoot,
    // wardrobe & puppeteer
    Restraints,
    Puppeteer,
    // toybox
    ToyboxDevices,
    ToyboxPatterns,
    ToyboxTriggers,
    ToyboxAlarms,
    VibeControl,
    // update monitoring.
    ChatDetours,
    ActionEffects,
    SpatialAudioController,
    SpatialAudioLogger,
    // UI
    UiCore,
    UserPairDrawer,
    Permissions,
    Simulation,

    // WebAPI
    PiShock,
    ApiCore,
    Callbacks,
    Health,
    HubFactory,
    JwtTokens,
}
