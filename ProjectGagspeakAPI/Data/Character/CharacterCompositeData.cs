using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterCompositeData
{
    // Gag Information, Updates to all ONLINE PLAYERS (even when u are offline)
    public CharacterAppearanceData AppearanceData { get; set; } = new();

    // Restraint set information, Updates to all ONLINE PLAYERS (even when u are offline)
    public CharacterWardrobeData WardrobeData { get; set; } = new();

    // Stores the list of alias triggers for all pairs, but when sending and receiving
    // only the pair we care about is handled. (makes it so we can push in bulk)
    public Dictionary<string, CharacterAliasData> AliasData { get; set; } = new();

    // stores the list of patterns you have in your toybox, and info for them (will also store trigger information) Updates to all ONLINE PLAYERS
    public CharacterToyboxData ToyboxData { get; set; } = new();
}
