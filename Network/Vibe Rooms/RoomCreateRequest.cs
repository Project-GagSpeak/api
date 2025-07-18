 using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The Room Creation DTO that initializes a new Vibe Room if validated.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomCreateRequest(string Name, RoomParticipant HostData)
{
    public string Description { get; init; } = string.Empty;
    public string[] Tags { get; init; } = [];
    public string? Password { get; init; } = null;
}
