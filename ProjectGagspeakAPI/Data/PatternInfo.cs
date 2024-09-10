using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PatternInfo
{
    /// <summary> The Unique Identifier for the Pattern </summary>
    public Guid Identifier = Guid.Empty;

    /// <summary> The name of the pattern </summary>
    public string Name = string.Empty;

    /// <summary> The description of the pattern </summary>
    public string Description = string.Empty;

    /// <summary> The duration of the pattern </summary>
    public TimeSpan Duration = TimeSpan.Zero;

    /// <summary> If the pattern should loop </summary>
    public bool ShouldLoop = false;
}
