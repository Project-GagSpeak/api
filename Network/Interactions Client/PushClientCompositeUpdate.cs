using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The Updated Composite Data for the client, that will be sent to all pairs.
/// </summary>
/// <param name="Recipients"> the Client's Kinkster pairs. </param>
/// <param name="WasSafeword"> If this update was due to a safeword or not. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientCompositeUpdate(List<UserData> Recipients, CharaCompositeData NewData, bool WasSafeword);
