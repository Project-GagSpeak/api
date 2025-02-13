using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Dto.Sharehub;

[MessagePackObject(keyAsPropertyName: true)]
public record MoodleSearchDto(string SearchString, HashSet<string> Tags, ResultFilter Filter, SearchSort Sort);


[MessagePackObject(keyAsPropertyName: true)]
public record PatternSearchDto(string SearchString, HashSet<string> Tags, ResultFilter Filter, DurationLength Length, SupportedTypes Types, SearchSort Sort);
