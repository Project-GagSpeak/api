using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Generic Pattern Info retrieved from search results.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublishedMoodle
{
    public string AuthorName = "ANONYMOUS";

    public MoodlesStatusInfo Status = new MoodlesStatusInfo();
}
