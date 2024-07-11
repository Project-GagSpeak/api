using Gagspeak.API.Data;
using MessagePack;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterPatternInfo
{
    // Properties specific to pattern info
    public List<PatternInfo> PatternList { get; set; } = new();
}
