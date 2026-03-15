using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
///   Generic LociData publish record.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublishedLociData(string AuthorName, LociStatusStruct Status);
