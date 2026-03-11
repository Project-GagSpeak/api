using MessagePack;
#pragma warning disable CS0659, IDE1006

namespace GagspeakAPI.Data;

/// <summary> 
///     Stores the Cached LociData for an actor.
/// </summary>
[MessagePackObject(keyAsPropertyName: true)]
public class CachedLociData
{
    public Dictionary<Guid, LociStatusInfo> DataInfo { get; set; } = [];
    public Dictionary<Guid, LociStatusInfo> Statuses { get; set; } = [];
    public Dictionary<Guid, LociPresetInfo> Presets { get; set; } = [];

    // Convenience access to collections.
    [IgnoreMember] public IEnumerable<LociStatusInfo> DataInfoList => DataInfo.Values;
    [IgnoreMember] public IEnumerable<LociStatusInfo> StatusList => Statuses.Values;
    [IgnoreMember] public IEnumerable<LociPresetInfo> PresetList => Presets.Values;

    public CachedLociData()
    { }

    public CachedLociData(CachedLociData other)
    {
        DataInfo = new Dictionary<Guid, LociStatusInfo>(other.DataInfo);
        Statuses = new Dictionary<Guid, LociStatusInfo>(other.Statuses);
        Presets = new Dictionary<Guid, LociPresetInfo>(other.Presets);
    }

    public void UpdateDataInfo(IEnumerable<LociStatusInfo> statuses)
        => DataInfo = statuses.ToDictionary(x => x.GUID, x => x);

    public bool TryUpdateStatus(LociStatusInfo status)
    {
        if (Statuses.ContainsKey(status.GUID))
        {
            Statuses[status.GUID] = status;
            return true;
        }
        return false;
    }

    public bool TryUpdatePreset(LociPresetInfo preset)
    {
        if (Presets.ContainsKey(preset.GUID))
        {
            Presets[preset.GUID] = preset;
            return true;
        }
        return false;
    }

    public void SetStatuses(IEnumerable<LociStatusInfo> statuses)
        => Statuses = statuses.ToDictionary(x => x.GUID, x => x);

    public void SetPresets(IEnumerable<LociPresetInfo> presets)
        => Presets = presets.ToDictionary(x => x.GUID, x => x);
}
#pragma warning restore CS0659, IDE1006
