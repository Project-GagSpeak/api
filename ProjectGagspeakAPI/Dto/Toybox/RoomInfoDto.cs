using GagspeakAPI.Data.Character;
using MessagePack;
using global::GagspeakAPI.Data;
using GagspeakAPI.Dto.User;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Updates devices of all users in a group that is not the caller.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomInfoDto(string NewRoomName, string RoomHost, List<string> ConnectedUsers);
