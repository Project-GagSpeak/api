using Gagspeak.API.Data;
using MessagePack;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterAliasData
{
    // the user UID that this alias data belongs to.
    public List<AliasTrigger> AliasList { get; set; } = new();
}
