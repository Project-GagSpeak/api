namespace GagSpeak.API.Data.Enum;

/// <summary>
/// A flag based enum that determines if a user has allowed another user to modify a certain
/// </summary>
[Flags]
public enum UserPermissionGeneralEditAccess
{
    NoAccessAllowed = 0,
    CommandsFromFriends = 1,
    CommandsFromParty = 2,
    LiveChatGarblerState = 4,
    LiveChatGarblerLocked = 8,
    ExtendedLockTimes = 16,
    MaxLockTime = 32,
}

[Flags]
public enum UserPermissionWardrobeEditAccess
{
    NoAccessAllowed = 0,
    WardrobeEnabled = 1,
    ItemAutoEquip = 2,
    RestraintSetAutoEquip = 4,
    LockGagStorageOnGagLock = 8,
    ApplyRestraintSets = 16,
    LockRestraintSets = 32,
    MaxAllowedRestraintTime = 64,
    RemoveRestraintSets = 128,
}

[Flags]
public enum UserPermissionPuppeteerEditAccess
{
    NoAccessAllowed = 0,
    PuppeteerEnabled = 1,
    AllowSitRequests = 2,
    AllowMotionRequests = 4,
    AllowAllRequests = 8,
}

[Flags]
public enum UserPermissionMoodlesEditAccess
{
    NoAccessAllowed = 0,
    MoodlesEnabled = 1,
    AllowPositiveStatusTypes = 2,
    AllowNegativeStatusTypes = 4,
    AllowSpecialStatusTypes = 8,
    PairCanApplyOwnMoodlesToYou = 16,
    PairCanApplyYourMoodlesToYou = 32,
    MaxMoodleTime = 64,
    AllowPermanentMoodles = 128,
}

[Flags] // note that it is likely better to to use a separate system for the intensity levels if we intent to do Realtime.
public enum UserPermissionToyboxEditAccess
{
    NoAccessAllowed = 0,
    ToyboxEnabled = 1,
    LockToyboxUI = 2,
    ToyIsActive = 4,
    SpatialVibratorAudio = 8,
    ChangeToyState = 16,
    CanControlIntensity = 32,
    VibratorAlarms = 64,
    CanUseRealtimeVibeRemote = 128,
    CanExecutePatterns = 256,
    CanExecuteTriggers = 512,
    CanCreateTriggers = 1024,
    CanSendTriggers = 2048,
}