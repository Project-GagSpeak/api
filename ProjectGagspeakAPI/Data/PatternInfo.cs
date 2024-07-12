using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public record PatternInfo
{
    /// <summary> The name of the pattern </summary>
    public string Name = string.Empty;

    /// <summary> The description of the pattern </summary>
    public string Description = string.Empty;

    /// <summary> The duration of the pattern </summary>
    public string Duration = string.Empty;

    /// <summary> If the pattern is active </summary>
    public bool IsActive = false;

    /// <summary> If the pattern should loop </summary>
    public bool ShouldLoop = false;
}
