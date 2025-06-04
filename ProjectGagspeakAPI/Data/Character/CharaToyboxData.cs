using GagspeakAPI.Enums;
using MessagePack;

namespace GagspeakAPI.Data;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaToyboxData
{
    public Guid ActivePattern { get; set; } = Guid.Empty;
    public List<Guid> ActiveAlarms { get; set; } = new List<Guid>();
    public List<Guid> ActiveTriggers { get; set; } = new List<Guid>();
}
