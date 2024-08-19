using MessagePack;

namespace GagspeakAPI.Data.Character;

/// <summary>
/// Stores Information about the Player's Moodles & Customize+ Data.
/// 
/// FOR MOODLES:
/// 
/// The Data contains the following.
/// 
/// 
/// 
/// 
/// 
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharacterIPCData
{
    /// <summary>
    /// The Pair's Latest known Status Manager Data (what moodles are actively applied)
    /// </summary>
//    public string MoodlesStatusManagerData { get; set; } = string.Empty;
    public string MoodlesData { get; set; } = string.Empty;

}
