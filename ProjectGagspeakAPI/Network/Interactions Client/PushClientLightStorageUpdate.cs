using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///    The updated LightStorage Data after an affected Identifier made changes to it.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PushClientLightStorageUpdate(List<UserData> Recipients, CharaLightStorageData NewData);
