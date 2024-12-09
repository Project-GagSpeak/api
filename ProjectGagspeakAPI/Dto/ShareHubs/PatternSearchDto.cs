using GagspeakAPI.Dto.User;
using GagspeakAPI.Data;
using MessagePack;
using GagspeakAPI.Enums;

namespace GagspeakAPI.Dto.Patterns;

/// <summary>
/// Search for patterns on the server.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PatternSearchDto(string SearchString, HashSet<string> Tags, ResultFilter Filter, DurationLength Length, SupportedTypes Types, SearchSort Sort);
