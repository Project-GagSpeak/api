using GagspeakAPI.Attributes;
using MessagePack;

namespace GagspeakAPI.Data;

[MessagePackObject(keyAsPropertyName: true)]
public record ServerPatternInfo
{
    public Guid Identifier = Guid.Empty;

    public string Label = "UNK PATTERN NAME";

    public string Description = string.Empty;
    
    public string Author = string.Empty;

    public HashSet<string> Tags = new HashSet<string>();

    public int Downloads = 0;

    public int Likes = 0;

    public bool Looping = false;

    public TimeSpan Length = TimeSpan.Zero;

    public DateTime UploadedDate = DateTime.MinValue;

    public ToyBrandName PrimaryDeviceUsed = ToyBrandName.Unknown;

    public ToyBrandName SecondaryDeviceUsed = ToyBrandName.Unknown;

    public ToyMotor MotorsUsed = ToyMotor.Unknown;

    public bool HasLiked = false;
}

// LEGACY STRUCTURE BELOW:
//[MessagePackObject(keyAsPropertyName: true)]
//public record ServerPatternInfo
//{
//    public Guid Identifier = Guid.Empty;

//    public string Label = "UNK PATTERN NAME";

//    public string Description = string.Empty;

//    public string Author = string.Empty;

//    public HashSet<string> Tags = new HashSet<string>();

//    public int Downloads = 0;

//    public int Likes = 0;

//    public bool Looping = false;

//    public TimeSpan Length = TimeSpan.Zero;

//    public DateTime UploadedDate = DateTime.MinValue;

//    public bool UsesVibrations = false;

//    public bool UsesRotations = false;

//    public bool HasLiked = false;
//}

