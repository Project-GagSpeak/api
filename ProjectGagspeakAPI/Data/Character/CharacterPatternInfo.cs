using GagspeakAPI.Data;
using MessagePack;
using ProjectGagspeakAPI.Data.VibeServer;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterToyboxInfo
{
    // Properties specific to pattern info
    public List<PatternInfo> PatternList { get; set; } = new();

    // properties specific to trigger info
    public List<TriggerInfo> TriggerList { get; set; } = new();

    // Properties specific to alarm info
    public List<AlarmInfo> AlarmList { get; set; } = new();
}
