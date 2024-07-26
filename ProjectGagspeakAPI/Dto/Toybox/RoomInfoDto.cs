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
public record RoomInfoDto(string NewRoomName, PrivateRoomUser RoomHost, List<PrivateRoomUser> ConnectedUsers);
