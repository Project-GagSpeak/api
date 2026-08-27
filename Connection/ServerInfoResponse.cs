using MessagePack;

namespace GagspeakAPI.Connection;

/// <summary>
///   Server Info Response that provides the total online users.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record ServerInfoResponse(int OnlineUsers);
