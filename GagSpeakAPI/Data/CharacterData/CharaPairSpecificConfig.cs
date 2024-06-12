using Gagspeak.API.Data.Enum;

namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// The character configuration that is unique for each paired client.
/// </summary>
public class CharaPairSpecificConfig
{
     public RoleLean Lean { get; set; } // the role lean you are for this paired user
     public bool ExtendedLockTimes { get; set; }  // if the client pair can lock you for extended times
     public bool InHardcore { get; set; } // if you have decided to enter hardcore mode with this paired user
     public PairSpecificConfigWardrobe WardrobePermissions { get; set; }
     public PairSpecificConfigPuppeteer PuppeteerPermissions { get; set; }
     public PairPairSpecificConfigToybox ToyboxPermissions { get; set; }
     public PairSpecificConfigHardcore HardcorePermissions { get; set; }
     public CharaPairSpecificConfig()
     {
          WardrobePermissions = new PairSpecificConfigWardrobe();
          PuppeteerPermissions = new PairSpecificConfigPuppeteer();
          ToyboxPermissions = new PairPairSpecificConfigToybox();
          HardcorePermissions = new PairSpecificConfigHardcore();
     }

     // missing the time of commitment attribute somewhere here...
}