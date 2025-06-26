using GagspeakAPI.Data;
using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     The updated LightStorage Data of a spesified <paramref name="User"/>.
/// </summary>
/// <param name="User"> The Kinkster the updated data is for. </param>
/// <param name="Enactor"> The Kinkster that caused the update, if applicable. </param>
[MessagePackObject(keyAsPropertyName: true)]
public record KinksterUpdateLightStorage(UserData User, UserData Enactor, CharaLightStorageData NewData) : KinksterBase(User);
