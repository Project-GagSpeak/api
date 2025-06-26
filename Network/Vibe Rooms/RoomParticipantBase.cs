using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Represents a participant in a Vibe Room.
/// </summary>
/// <param name="User"></param>
/// <param name="DisplayName"> The User's Anonymous Identity for VibeRooms </param>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomParticipantBase(UserData User, string DisplayName);
