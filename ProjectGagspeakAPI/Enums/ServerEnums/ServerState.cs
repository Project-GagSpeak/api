namespace GagspeakAPI.Enums;


public enum ServerState
{
    Offline,
    Connecting,
    Reconnecting,
    Disconnecting,
    Disconnected,
    Connected,
    Unauthorized,
    VersionMisMatch,
    NoSecretKey,
    ForcedReconnect,
}
