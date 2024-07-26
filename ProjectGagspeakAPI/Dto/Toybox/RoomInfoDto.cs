using GagspeakAPI.Data.Character;
using MessagePack;
using global::GagspeakAPI.Data;
using GagspeakAPI.Dto.User;
using GagspeakAPI.Data.VibeServer;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Updates devices of all users in a group that is not the caller.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomInfoDto
{
    public string NewRoomName { get; set; } = "";
    public PrivateRoomUser RoomHost { get; set; } = new("", "", false, false);
    public List<PrivateRoomUser> ConnectedUsers { get; set; } = [];
}