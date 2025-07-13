using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     An Invite that is issued to another Kinkster, allowing them to join private rooms.
/// </summary>
/// <remarks>
///     In a <b>Server Call</b>, <paramref name="User"/> is the Kinkster the invite is sent to,
///     In a <b>Callback</b>, <paramref name="User"/> is the Kinkster that sent the invite.
/// </remarks>
[MessagePackObject(keyAsPropertyName: true)]
public record RoomInvite(UserData User, string RoomName)
{
    public string? AttachedMessage { get; set; } = string.Empty;
    public string? RoomPassword { get; set; } = string.Empty;
}
