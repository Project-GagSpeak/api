namespace GagspeakAPI.Enums;


public enum ServerState
{
    Offline,
    // Connection States.
    Disconnected,
    Disconnecting,
    Reconnecting,
    Connecting,
    Connected,
    ConnectedDataSynced,
    // Error Messages
    Unauthorized,
    VersionMisMatch,
    Unattached,
    NoSecretKey,
    // Occurs from Discord
    ForcedReconnect,
}
