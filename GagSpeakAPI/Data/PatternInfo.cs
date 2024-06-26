using MessagePack;

namespace Gagspeak.API.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
public class PatternInfo
{
    public string Name = string.Empty;
    public string Description = string.Empty;
    public string Duration = string.Empty;
    public bool IsActive = false;
    public bool ShouldLoop = false;
}