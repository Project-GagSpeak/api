using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary> 
///     The Kinkster we wish to send a request to, and the message to attach with it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record CreateKinksterRequest(UserData User, string Message) : KinksterBase(User);
