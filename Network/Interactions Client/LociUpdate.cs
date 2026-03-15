using GagspeakAPI.Data;
using MessagePack;

namespace GagspeakAPI.Network;

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociData(List<UserData> Recipients, LociContainerData Data);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociStatuses(List<UserData> Recipients, List<LociStatusStruct> Statuses);

[MessagePackObject(keyAsPropertyName: true)]
public record PushLociPresets(List<UserData> Recipients, List<LociPresetStruct> Presets);

[MessagePackObject(keyAsPropertyName: true)]
public record PushStatusModified(List<UserData> Recipients, LociStatusStruct Status, bool Deleted);

[MessagePackObject(keyAsPropertyName: true)]
public record PushPresetModified(List<UserData> Recipients, LociPresetStruct Preset, bool Deleted);
