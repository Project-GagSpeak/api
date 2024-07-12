using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and appearance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterCompositeData
{
    // IPC Data (Moodles), Updates to all VISIBLE PLAYERS
    public CharacterIPCData IPCData { get; set; } = new();

    // Gag Information, Updates to all ONLINE PLAYERS (even when u are offline)
    public CharacterAppearanceData AppearanceData { get; set; } = new();

    // Restraint set information, Updates to all ONLINE PLAYERS (even when u are offline)
    public CharacterWardrobeData WardrobeData { get; set; } = new();

    // Stores all of the puppeteer alias data for a user (stored per-pair) (currently isn't but i need to fit it) Updates to all ONLINE PLAYERS
    public CharacterAliasData AliasData { get; set; } = new();

    // stores the list of patterns you have in your toybox, and info for them (will also store trigger information) Updates to all ONLINE PLAYERS
    public CharacterPatternInfo PatternData { get; set; } = new();
}
