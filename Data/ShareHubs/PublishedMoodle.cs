using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Generic Pattern Info retrieved from search results.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublishedLociData
{
    public string AuthorName = "ANONYMOUS";

    public LociStatusInfo Status = new LociStatusInfo();
}
