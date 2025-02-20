using MessagePack;
#pragma warning disable CS0659

namespace GagspeakAPI.Data.Character;

/// <summary> Stores Information about the Player's Moodles Data </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaIPCData
{
    /// <summary> Last Known StatusManager compressed in base64 string. (for easy setting) </summary>
    public string MoodlesData { get; set; } = string.Empty;

    /// <summary> The list of Active Statuses in the StatusManager, non-serialized. </summary>
    public List<MoodlesStatusInfo> MoodlesDataStatuses { get; set; } = new();

    /// <summary> A list of the player's Statuses. </summary>
    public List<MoodlesStatusInfo> MoodlesStatuses { get; set; } = new();

    /// <summary> List of player's Presets, and the Status GUID's the preset contains </summary>
    public List<MoodlePresetInfo> MoodlesPresets { get; set; } = new();

    public CharaIPCData() { }
    public CharaIPCData(CharaIPCData other)
    {
        MoodlesData = other.MoodlesData;
        MoodlesDataStatuses = new List<MoodlesStatusInfo>(other.MoodlesDataStatuses);
        MoodlesStatuses = new List<MoodlesStatusInfo>(other.MoodlesStatuses);
        MoodlesPresets = new List<MoodlePresetInfo>(other.MoodlesPresets);
    }

    /// <summary> Equals Override to ensure things are the same. </summary>
    public override bool Equals(object? obj)
    {
        // return false if object is not characterIPCData
        if (obj is CharaIPCData data)
        {
            return MoodlesData == data.MoodlesData
                && MoodlesDataStatuses.SequenceEqual(data.MoodlesDataStatuses)
                && MoodlesStatuses.SequenceEqual(data.MoodlesStatuses)
                && MoodlesPresets.SequenceEqual(data.MoodlesPresets);
        }
        return false;
    }
}
#pragma warning restore CS0659
