using MessagePack;

namespace Gagspeak.API.Data;

/// <summary>
/// Stores a list of alias triggers. This is intended to be applied once for each player in your whitelist.
/// </summary>
public class AliasTrigger
{
    public bool Enabled { get; set; } = false;
    public string InputCommand { get; set; } = string.Empty;
    public string OutputCommand { get; set; } = string.Empty;
}