using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

[Flags]
public enum RoomSettings
{
    None = 0x00,
    Public = 0x01,
    PasswordProtected = 0x02
}

/// <summary> Defines the details of a room requested to be created. </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record NewVibeRoomDto(string Name, RoomSettings Settings)
{
    public string? Password { get; init; }
    public List<string> RoomTags { get; init; } = new List<string>();
}
