using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Search request for moodles.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodleSearch(string input, HashSet<string> Tags, ResultFilter Filter, SearchSort Sort);
