using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
///     Generic Pattern Info retrieved from search results.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PublishedPattern
{
    public int Version = 2;
    public Guid Identifier = Guid.Empty;

    public string Label = "UNK PATTERN NAME";

    public string Description = string.Empty;
    
    public string Author = "ANONYMOUS";

    public bool Looping = false;

    public TimeSpan Length = TimeSpan.Zero;

    public DateTime UploadedDate = DateTime.MinValue;

    public ToyBrandName PrimaryDevice = ToyBrandName.Unknown;

    public ToyBrandName SecondaryDevice = ToyBrandName.Unknown;

    public ToyMotor MotorsUsed = ToyMotor.Unknown;
}
