namespace GagspeakAPI.Data.Enum;

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
