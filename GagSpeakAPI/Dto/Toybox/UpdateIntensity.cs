using GagSpeak.API.Data.Character;
using MessagePack;
using global::Gagspeak.API.Data;

namespace GagSpeak.API.Dto.Toybox;

/// <summary>
/// Update the intensity of the list of user's toys
/// 
/// Highly dependent on being extremely fast and efficient, as it will be called frequently.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record UpdateIntensityDto(List<string> RecipientUIDs, byte newIntensityLevel);
