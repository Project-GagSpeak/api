using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gagspeak.API.Data;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterAliasData
{
    // Properties specific to alias data
    public List<AliasTrigger> AliasList { get; set; } = new();
}
