using MessagePack;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterCompositeData
{
    // should be a collection of all below classes
    public CharacterIPCData IPCData { get; set; } = new();
    public CharacterAppearanceData AppearanceData { get; set; } = new();
    public CharacterWardrobeData WardrobeData { get; set; } = new();
    public CharacterAliasData AliasData { get; set; } = new();
    public CharacterPatternInfo PatternData { get; set; } = new();
}