using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Search request for patterns.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PatternSearch(string input, HashSet<string> Tags, ResultFilter Filter,
    DurationLength Length, SupportedTypes Types, SearchSort Sort);
