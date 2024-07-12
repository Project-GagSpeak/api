using GagspeakAPI.Data.Character;
using MessagePack;
using global::GagspeakAPI.Data;

namespace GagspeakAPI.Dto.Toybox;

/// <summary>
/// Update the intensity of the list of user's toys
/// 
/// Highly dependent on being extremely fast and efficient, as it will be called frequently.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record NewIntensityDto(byte newIntensityLevel);
