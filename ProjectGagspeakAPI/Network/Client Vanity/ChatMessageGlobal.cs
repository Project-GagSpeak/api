using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record ChatMessageGlobal(UserData Sender, string Message, bool LegacyId)
{
    [IgnoreMember]
    public string UserTagCode => LegacyId
        ? Sender.UID.Substring(Sender.UID.Length - 3) 
        : Sender.UID.Substring(Sender.UID.Length - 4);
}
