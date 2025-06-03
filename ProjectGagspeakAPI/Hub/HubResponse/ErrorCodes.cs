namespace GagspeakAPI.Hub;

/// <summary> All Error Codes for GagSpeak API calls. </summary>
/// <remarks> Only generics are marked to future proof additional errors. </remarks>
public enum GagSpeakApiEc
{
    /// <summary> Indicates a successful interaction. </summary>
    Success = 0,

    /// <summary> Network Connection not established or was terminated. </summary>
    NetworkError = 1,

    /// <summary> The passed in object was not the desired datatype. </summary>
    IncorrectDataType = 2,

    /// <summary> The passed in data was null or invalid. </summary>
    NullData = 3,

    /// <summary> The Recipient was not who it should be. </summary>
    InvalidRecipient = 4,


    // ----- ShareHub Spesific Errors -----

    /// <summary> Prevent Reuploads or Duplicates. </summary>
    DuplicateEntry,

    /// <summary> Upload limit per week is exceeded. </summary>
    UploadLimitExceeded,

    /// <summary> The requested entry does not exist. </summary>
    ShareHubEntryNotFound,

    /// <summary> Not the publisher, so you cannot remove the shareHub item. </summary>
    NotPublisher,

    // ----- Client Vanity Spesific Errors -----

    /// <summary> The provided image file is not in PNG format. </summary>
    InvalidImageFormat,

    /// <summary> The provided image file is larger than 256x256. </summary>
    InvalidImageSize,

    /// <summary> Reporting someone you already have an active report on. </summary>
    AlreadyReported,

    /// <summary> The reported user does not even have a profile yet. </summary>
    KinkPlateNotFound,


    // ----- Interaction Spesific Errors -----

    /// <summary> Cant send Request to someone already paired. </summary>
    AlreadyPaired,

    /// <summary> A Request for the recipient was already made by the sender. </summary>
    KinksterRequestExists,

    /// <summary> Cannot cancel a request that no longer exists. </summary>
    KinksterRequestNotFound,

    /// <summary> Not paired with the intended recipient. </summary>
    NotPaired,

    /// <summary> The incorrect updateKind was used for the call made. </summary>
    BadUpdateKind,

    /// <summary> You lack the nessisary permissions to execute the call on the user. </summary>
    LackingPermissions,

    /// <summary> The Layer to update was out of bounds. </summary>
    InvalidLayer,

    /// <summary> The provided password is incorrect. </summary>
    InvalidPassword,

    /// <summary> The provided time value is invalid. </summary>
    InvalidTime,

    /// <summary> cannot lock when nothing is applied. </summary>
    NoActiveItem,

    /// <summary> The item is already locked. </summary>
    ItemIsLocked,

    /// <summary> For locks or items that can only be removed by the enabler. </summary>
    NotItemEnabler,

    /// <summary> For locks or items that can only be removed by the assigner. </summary>
    NotItemAssigner,


    // ----- Vibe Room Spesific Errors -----

    /// <summary> A Vibe Room with the same name exists. </summary>
    RoomNameExists,

    /// <summary> The vibe room is not found. </summary>
    RoomNotFound,

    /// <summary> Cannot send an invite to a room you are not the host of. </summary>
    NotRoomHost,

    /// <summary> Cannot join another room while still in one. </summary>
    AlreadyInRoom,
}
