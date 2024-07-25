using GagspeakAPI.Data.Character;
using MessagePack;
using global::GagspeakAPI.Data;
using GagspeakAPI.Dto.User;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Sends a chat message to the other users in the room.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomMessageDto(string SenderName, string RoomName, string Message);
