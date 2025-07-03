 using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The Room Creation DTO that initializes a new Vibe Room if validated.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomCreateRequest(string Name, VibeRoomFlags Settings)
{
    public string? Password { get; init; }
    public List<string> RoomTags { get; init; } = [];
}
