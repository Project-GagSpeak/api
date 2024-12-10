using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Generic Pattern Info retrieved from search results.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublishedPattern
{
    public Guid Identifier = Guid.Empty;

    public string Name = "UNK PATTERN NAME";

    public string Description = string.Empty;
    
    public string Author = "ANONYMOUS";

    public bool Looping = false;

    public TimeSpan Length = TimeSpan.Zero;

    public DateTime UploadedDate = DateTime.MinValue;
}
