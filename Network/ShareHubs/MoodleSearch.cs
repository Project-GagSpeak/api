using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Network;

/// <summary>
///     Search request for moodles.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record MoodleSearch(string Input, HashSet<string> Tags, ResultFilter Filter, SearchSort Sort);
