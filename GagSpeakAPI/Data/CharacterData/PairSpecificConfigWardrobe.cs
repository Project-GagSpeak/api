using Gagspeak.API.Data.Enum;
using MessagePack;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the wardrobe module unique to each paired user.
/// </summary>
public class PairSpecificConfigWardrobe
{
     public bool ToggleRestraintSets { get; set; } // if the client pair can toggle your restraint sets.
     public bool LockRestraintSets { get; set; }   // if the client pair can lock your restraint sets  
}