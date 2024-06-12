using MessagePack;

namespace Gagspeak.API.Data.CharacterData;

/// <summary>
/// CharacterData class stores all of the user's settings, permissions, and apperance data
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterData
{
     public CharaGeneralConfig GeneralConfig { get; set; }
     public CharaAppearanceConfig AppearanceConfig { get; set; }
     public Dictionary<string, CharaPairSpecificConfig> PairSpecificConfig { get; set; }

     public CharacterData()
     {
          GeneralConfig = new CharaGeneralConfig();
          AppearanceConfig = new CharaAppearanceConfig();
          PairSpecificConfig = new Dictionary<string, CharaPairSpecificConfig>();
     }
}