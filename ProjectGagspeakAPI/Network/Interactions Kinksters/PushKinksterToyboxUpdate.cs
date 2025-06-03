using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Modifies a Client Caller's Kinkster Pair's Toybox Data, and synchronizes it with the other pairs.
/// </summary>
/// <param name="Target"> The Kinkster that the update is for. </param>
/// <param name="LatestData"> The <paramref name="Target"/>'s latest Toybox Data, before the update. </param>
/// <param name="Item"> The Item interacted with that caused the update change we are requesting. </param>
/// <param name="Type"> The type of update that was made. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record PushKinksterToyboxUpdate(UserData Target, CharaToyboxData LatestData, Guid Item, DataUpdateType Type) : KinksterBase(Target);

