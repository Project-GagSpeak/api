using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociData(List<UserData> Recipients, CachedLociData Data);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociStatuses(List<UserData> Recipients, List<LociStatusInfo> Statuses);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociPresets(List<UserData> Recipients, List<LociPresetInfo> Presets);

[MessagePackObject(keyAsPropertyName: true)]
public record PushStatusModified(List<UserData> Recipients, LociStatusInfo Status, bool Deleted);

[MessagePackObject(keyAsPropertyName: true)]
public record PushPresetModified(List<UserData> Recipients, LociPresetInfo Preset, bool Deleted);
