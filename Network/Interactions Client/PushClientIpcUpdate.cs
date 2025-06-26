using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Composite Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientIpcUpdate(List<UserData> Recipients, CharaIPCData NewData, DataUpdateType Type);
