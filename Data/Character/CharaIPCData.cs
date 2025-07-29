using MessagePack;
#pragma warning disable CS0659, IDE1006

namespace GagspeakAPI.Data;

/// <summary> 
///     Stores Information about the Player's Moodles Data <para />
///     If this is creating noticable performance issues, reduce to a
///     list and make a local client friendly dictionary version. 
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CharaIPCData : IEquatable<CharaIPCData>
{
    public string DataString { get; private set; } = string.Empty;
    public Dictionary<Guid, MoodlesStatusInfo> DataInfo { get; private set; } = new Dictionary<Guid, MoodlesStatusInfo>();
    public Dictionary<Guid, MoodlesStatusInfo> Statuses { get; private set; } = new Dictionary<Guid, MoodlesStatusInfo>();
    public Dictionary<Guid, MoodlePresetInfo> Presets { get; private set; } = new Dictionary<Guid, MoodlePresetInfo>();

    // Convenience access to collections.
    [IgnoreMember] public IEnumerable<MoodlesStatusInfo> DataInfoList => DataInfo.Values;
    [IgnoreMember] public IEnumerable<MoodlesStatusInfo> StatusList => Statuses.Values;
    [IgnoreMember] public IEnumerable<MoodlePresetInfo> PresetList => Presets.Values;

    public CharaIPCData()
    { }

    public CharaIPCData(CharaIPCData other)
    {
        DataString = other.DataString;
        DataInfo = new Dictionary<Guid, MoodlesStatusInfo>(other.DataInfo);
        Statuses = new Dictionary<Guid, MoodlesStatusInfo>(other.Statuses);
        Presets = new Dictionary<Guid, MoodlePresetInfo>(other.Presets);
    }

    public void UpdateDataInfo(string dataString, IEnumerable<MoodlesStatusInfo> statuses)
    {
        DataString = dataString;
        DataInfo = statuses.ToDictionary(x => x.GUID, x => x);
    }

    public bool TryUpdateStatus(MoodlesStatusInfo status)
    {
        if(Statuses.ContainsKey(status.GUID))
        {
            Statuses[status.GUID] = status;
            return true;
        }
        return false;
    }

    public bool TryUpdatePreset(MoodlePresetInfo preset)
    {
        if (Presets.ContainsKey(preset.GUID))
        {
            Presets[preset.GUID] = preset;
            return true;
        }
        return false;
    }

    public void SetStatuses(IEnumerable<MoodlesStatusInfo> statuses)
        => Statuses = statuses.ToDictionary(x => x.GUID, x => x);

    public void SetPresets(IEnumerable<MoodlePresetInfo> presets)
        => Presets = presets.ToDictionary(x => x.GUID, x => x);

    public bool Equals(CharaIPCData? other)
        => other is not null && DataString == other.DataString;

    public override bool Equals(object? obj)
        => obj is CharaIPCData other && Equals(other);

    public override int GetHashCode()
        => DataString.GetHashCode();

    public IEnumerable<MoodlesStatusInfo> GetStatusesForPreset(Guid presetId)
    {
        if (!Presets.TryGetValue(presetId, out var preset))
            yield break; // Return Empty if preset not found.

        foreach (var id in preset.Statuses)
        {
            if (Statuses.TryGetValue(id, out var status))
                yield return status;
        }
    }
}
#pragma warning restore CS0659, IDE1006
