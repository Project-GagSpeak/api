using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Dto;

[MessagePackObject(keyAsPropertyName: true)]
public record GlobalChatMessageDto(UserData MessageSender, string Message, bool useThreeCharId)
{
    [IgnoreMember]
    public string UserTagCode => useThreeCharId 
        ? MessageSender.UID.Substring(MessageSender.UID.Length - 3) 
        : MessageSender.UID.Substring(MessageSender.UID.Length - 4);
}
