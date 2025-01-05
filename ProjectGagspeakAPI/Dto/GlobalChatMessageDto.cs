using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Sends a chat message to the other users in the room.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record GlobalChatMessageDto(UserData MessageSender, string Message, bool useThreeCharId)
{
    [IgnoreMember]
    public string UserTagCode => useThreeCharId ? MessageSender.UID.Substring(MessageSender.UID.Length - 3) : MessageSender.UID.Substring(MessageSender.UID.Length - 4);
}

/// <summary>
/// Sends a chat message to a private group room with another pair.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PairChatMessageDto(UserData MessageSender, string GroupName, string Message);
