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
    public string MoodlesData { get; set; } = string.Empty;

    /// <summary>
    /// A list of the player's Moodles Statuses.
    /// </summary>
    public List<MoodlesStatusInfo> MoodlesStatuses { get; set; } = new();

    /// <summary>
    /// A dictionary of the players Moodle Presets, along with the associated Moodles Statuses that come with them.
    /// 
    /// TODO: Consider narrowing this down to a list of GUID's. As all the status info's should be in the moodlesStatuses list.
    /// </summary>
    public List<(Guid, List<Guid>)> MoodlesPresets { get; set; } = new();

}
