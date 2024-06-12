namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// Configurations for the hardcore module unique to each paired user.
/// </summary>
public class PairSpecificConfigHardcore
{
     public bool AllowForcedFollow { get; set; } = false;     // if you give player permission
     public bool IsForcedToFollow { get; set; } = false;      // if the player has activated it
     public bool AllowForcedSit { get; set; } = false;        // if you give player permission
     public bool IsForcedToSit { get; set; } = false;         // if the player has activated it 
     public bool AllowForcedToStay { get; set; } = false;     // if you give player permission
     public bool IsForcedToStay { get; set; } = false;        // if the player has activated it
     public bool AllowBlindfold { get; set; } = false;       // if you give player permission
     public bool ForceLockFirstPerson { get; set; } = false; // if you force first person view
     public bool IsBlindfoldeded { get; set; } = false;      // if the player has activated it
}