namespace GagspeakAPI.Chat;

/// <summary>
///   WHat is allowed in GlobalChat
/// </summary>
[Flags]
public enum ChatFlags : ushort
{
    /// <summary>
    ///   Assume Lurker state.
    /// </summary>
    None = 0 << 0,

    /// <summary>
    ///   In place of an Anon-User name, use the vanity display name.  
    /// </summary>
    UseDisplayName = 1 << 0,

    /// <summary>
    ///   Let others know when you are rendered nearby.
    /// </summary>
    ShowVisibility = 1 << 1,

    /// <summary>
    ///   Allows others to focus target on hover, set focus target, or target.
    /// </summary>
    AllowTargeting = 1 << 2,

    /// <summary>
    ///   If your nameplate can change colors or add symbols to indicate presence.
    /// </summary>
    AllowNameplateEdits = 1 << 3,

    /// <summary>
    ///   Allows others to view your profile (matches Anon-Name)
    /// </summary>
    AllowProfileViewing = 1 << 4,

    /// <summary>
    ///   Allows others from radar to send you a direct message.
    /// </summary>
    AllowDirectMessages = 1 << 5,

    /// <summary>
    ///   Allows others to send you a pair request.
    /// </summary>
    AllowRequests = 1 << 6,

    /// <summary>
    ///   Enforce requests sent to you as permanent, to become temporary instead.
    /// </summary>
    EnforceTemporary = 1 << 7,
}
