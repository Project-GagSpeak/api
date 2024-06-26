using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Gagspeak.API.Data;

namespace GagSpeak.API.Data.Character;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterIPCData
{
    // Properties specific to IPC data (making this modular for the sake of scalibility
    public string MoodlesData { get; set; } = string.Empty;
}