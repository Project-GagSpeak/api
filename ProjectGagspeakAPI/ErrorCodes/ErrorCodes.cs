namespace GagspeakAPI;

/// <summary> Generic Return Codes for API calls. </summary>
public enum GsApiErrorCodes
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0x00,

    /// <summary> The retrieved data was null. </summary>
    NullEntry = 0x01,

    /// <summary> The data we want to update does not exist. </summary>
    NoEntryFound = 0x02,

    /// <summary> Was unable to remove the entry from the server. </summary>
    DeleteFailed = 0x04,

    /// <summary> Interacted with GagData </summary>
    GagRelated = 0x08,

    /// <summary> Interacted with RestrictionData </summary>
    RestrictionRelated = 0x10,

    /// <summary> Interacted with RestraintData </summary>
    RestraintRelated = 0x20,

    /// <summary> Interacted with CursedLootData </summary>
    CursedLootRelated = 0x40,

    /// <summary> Interacted with AliasData </summary>
    AliasRelated = 0x80,

    /// <summary> Interacted with ToyboxData </summary>
    ToyboxRelated = 0x100,

    /// <summary> Interacted with OrdersData </summary>
    OrdersRelated = 0x200,

    /// <summary> Interacted with IpcData </summary>
    IpcRelated = 0x400,

    /// <summary> No Layer was available for cursed loot. </summary>
    NoAvailableLayer = 0x800,

    /// <summary> Tried to interact with a layer restricted or out of bounds. </summary>
    InvalidLayer = 0x1000,

    /// <summary> the DataUpdateKind was not an expected type. </summary>
    BadDataUpdateKind = 0x2000,

    /// <summary> Not Connected </summary>
    NotConnected = 0x4000,
}

public enum GsApiVibeErrorCodes
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0x00,

    MethodNotImplemented = 0x01,
    /// <summary> The retrieved data was null. </summary>
    NullEntry = 0x02,
    /// <summary> The data we want to update does not exist. </summary>
    NoEntryFound = 0x04,
    /// <summary> Was unable to remove the entry from the server. </summary>
    DeleteFailed = 0x08,

    /// <summary> Not Currently Connected. </summary>
    NotConnected = 0x10,
}

public enum GsApiPairErrorCodes
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0x00,

    // General Errors (0x01 - 0x08)
    /// <summary> The retrieved data was null. </summary>
    NullEntry = 0x01,

    /// <summary> The data we want to update does not exist. </summary>
    NoEntryFound = 0x02,

    /// <summary> Was unable to remove the entry from the server. </summary>
    DeleteFailed = 0x04,

    /// <summary> Invalid update type provided. </summary>
    BadDataUpdateKind = 0x08,

    // Permission & Relationship Errors (0x10 - 0x40)
    /// <summary> If User attempts to update their own data. </summary>
    AttemptedSelfChange = 0x10,

    /// <summary> You are not paired with the person you are updating. </summary>
    NotPaired = 0x20,

    /// <summary> Attempted to edit a layer that doesn't exist. </summary>
    InvalidLayer = 0x40,

    // Gag State Errors (0x80 - 0x400)
    /// <summary> No active item is present to modify. </summary>
    NoActiveItem = 0x80,

    /// <summary> The item is already locked. </summary>
    AlreadyLocked = 0x100,

    /// <summary> The item is not currently locked. </summary>
    NotCurrentlyLocked = 0x200,

    // Permission Errors (0x400 - 0x1000)
    /// <summary> User does not have permission for this action. </summary>
    PermissionDenied = 0x400,

    /// <summary> No padlock was selected for locking. </summary>
    NoPadlockSelected = 0x800,

    /// <summary> Permanent locks are not allowed. </summary>
    PermanentDenied = 0x1000,

    /// <summary> Owner locks are not allowed. </summary>
    OwnerDenied = 0x2000,

    /// <summary> Devotional locks are not allowed. </summary>
    DevotionalDenied = 0x4000,

    // Validation Errors (0x8000 - 0x10000)
    /// <summary> The combination of inputs is invalid. </summary>
    InvalidCombination = 0x8000,

    /// <summary> The provided password is incorrect. </summary>
    InvalidPassword = 0x10000,

    /// <summary> The provided time value is invalid. </summary>
    InvalidTime = 0x20000,

    // Special Role Restrictions (0x40000)
    /// <summary> The user is not the assigned lock owner. </summary>
    NotLockAssigner = 0x40000,

    /// <summary> Not Currently Connected. </summary>
    NotConnected = 0x80000,
}

public enum GsApiPermErrorCodes
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0x00,

    /// <summary> If User attempts to update their own data. </summary>
    AttemptedSelfChange = 0x01,

    /// <summary> You are not paired with the person you are updating. </summary>
    NotPaired = 0x02,

    /// <summary> Not allowed to change the pairs permissions. </summary>
    PermissionDenied = 0x04,

    /// <summary> The permission name (entry) doesn't exist in the class. </summary>
    NoEntryFound = 0x08,

    /// <summary> Incorrectly assigned value type to defined property type. </summary>
    InvalidDataType = 0x10,

    /// <summary> Not Currently Connected. </summary>
    NotConnected = 0x20,
}


public static class ErrorCodeExtensions
{
    public static bool HasAny(this GsApiErrorCodes flags, GsApiErrorCodes check) => (flags & check) != 0;
}
