using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Represents a participant in a Vibe Room.
/// </summary>
/// <param name="User"></param>
/// <param name="DisplayName"> The User's Anonymous Identity for VibeRooms </param>
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomParticipant(UserData User, string DisplayName) : RoomParticipantBase(User, DisplayName)
{
    public bool IsHost { get; set; } = false;
    public List<string> AllowedParticipants { get; set; } = [];
    public List<ToyInfo> Devices { get; set; } = [];
}
