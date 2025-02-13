using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.VibeRoom;

[MessagePackObject(keyAsPropertyName: true)]
public record VibeRoomInviteDto(UserData User, string RoomName, string RoomPassword)
{
    public string AttachedMessage { get; init; } = string.Empty;
}
